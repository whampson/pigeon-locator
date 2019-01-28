#region License
/* Copyright (c) 2018-2019 W. Hampson
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WHampson.PigeonLocator
{
    /// <summary>
    /// Represents a first in, first out data structure containing unique elements
    /// with a fixed maximum element count.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    public class FixedLengthUniqueQueue<T> : IEnumerable<T>
    {
        private List<T> q;

        /// <summary>
        /// Creates a new <see cref="FixedLengthUniqueQueue{T}"/> instance.
        /// </summary>
        /// <param name="capacity">The maximum number of elements that the queue can hold.</param>
        public FixedLengthUniqueQueue(int capacity)
        {
            if (capacity < 1) {
                throw new ArgumentException("Capacity must be a positive integer.", nameof(capacity));
            }

            Capacity = capacity;
            q = new List<T>();
        }

        /// <summary>
        /// Gets the maximum number of elements that the queue can hold.
        /// </summary>
        public int Capacity
        {
            get;
        }

        /// <summary>
        /// Gets the number of elements currently in the queue.
        /// </summary>
        public int Count
        {
            get { return q.Count; }
        }

        /// <summary>
        /// Gets the element at the front of the queue without removing it.
        /// </summary>
        /// <returns>The item at the front of the queue.</returns>
        public T Peek()
        {
            if (Count == 0) {
                throw new InvalidOperationException("Queue empty.");
            }

            return q[0];
        }

        /// <summary>
        /// Adds a new element to the queue. If the element already exists
        /// in the queue, the element is brought to the rear of the queue.
        /// If the queue is at maximum capacity, the item at the front of the
        /// queue is automatically dequeued.
        /// </summary>
        /// <param name="item">The item to add to the queue.</param>
        public void Enqueue(T item)
        {
            if (q.Contains(item)) {
                if (q.Last().Equals(item)) {
                    return;
                }
                int idx = q.IndexOf(item);
                q.RemoveAt(idx);
                q.Add(item);
                return;
            }

            while (Count + 1 > Capacity) {
                Dequeue();
            }
            q.Add(item);
        }

        /// <summary>
        /// Removes the element at the front of the queue.
        /// </summary>
        /// <returns>The item at the front of the queue.</returns>
        public T Dequeue()
        {
            if (Count == 0) {
                throw new InvalidOperationException("Queue empty.");
            }

            T item = q[0];
            q.RemoveAt(0);

            return item;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < Count; i++) {
                s += q[i] + " ";
            }

            return s.TrimEnd();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in q) {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
