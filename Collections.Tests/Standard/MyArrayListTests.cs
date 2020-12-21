using Collections.Standard;
using System;
using System.Collections;
using Xunit;

namespace Collections.Tests.Standard
{
    public class MyArrayListTests
    {
        [Fact]
        public void Should_default_array_capacity_be_four()
        {
            var arrayList = new MyArrayList();
            Assert.Equal(4, arrayList.Capacity);
        }

        [Fact]
        public void Should_count_be_zero_when_initializing_empty()
        {
            var arrayList = new MyArrayList();
            Assert.Equal(0, arrayList.Count);
        }

        [Fact]
        public void Should_capacity_be_equal_with_initial_capacity()
        {
            var arrayList = new MyArrayList(5);
            Assert.Equal(5, arrayList.Capacity);
        }

        [Fact]
        public void Should_throw_ArgumentOutOfRangeException_when_initial_capacity_is_lesser_than_zero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MyArrayList(-1));
        }

        [Fact]
        public void Should_iterate_once()
        {
            var arrayList = new MyArrayList(1);
            arrayList.Add(0);

            var iterations = 0;
            foreach(var item in arrayList)
            {
                iterations++;
            }

            Assert.Equal(1, iterations);
        }

        [Fact]
        public void Should_add_element()
        {
            var arrayList = new MyArrayList();
            var insertedIndex = arrayList.Add(5);

            Assert.Equal(0, insertedIndex);
            Assert.Single(arrayList);
        }

        [Fact]
        public void Should_resize_array_when_size_is_greater_than_capacity()
        {
            var arrayList = new MyArrayList(2);
            arrayList.Add(0);
            arrayList.Add(1);
            arrayList.Add(2);

            Assert.Equal(3, arrayList.Count);
            Assert.Equal(3, arrayList.Capacity);
        }

        [Fact]
        public void Should_add_a_thousand_elements_correctly()
        {
            var arrayList = new MyArrayList(2);

            for (var i = 0; i < 1000; i++)
            {
                arrayList.Add(i);
            }

            Assert.Equal(1000, arrayList.Count);
            Assert.Equal(1000, arrayList.Capacity);
        }

        [Fact]
        public void Should_remove_element()
        {
            var arrayList = new MyArrayList();
            arrayList.Add(5);
            arrayList.Add("test");

            arrayList.Remove("test");

            Assert.Single(arrayList);
        }

        [Fact]
        public void Should_throw_ArgumentOutOfRangeException_when_calling_remove_with_null()
        {
            var arrayListTarget = new MyArrayList();
            Assert.Throws<ArgumentOutOfRangeException>(() => arrayListTarget.Remove(null));
        }

        [Fact]
        public void Should_remove_element_and_shift_elements_to_the_left()
        {
            var arrayList = new MyArrayList();
            arrayList.Add(5);
            arrayList.Add(1);
            arrayList.Add("test");
            arrayList.Add(8);
            arrayList.Add("car");
            arrayList.Add("bike");

            arrayList.Remove("test");
            arrayList.Remove(8);

            Assert.Equal("bike", arrayList[3]);
        }

        [Fact]
        public void Should_clear_elements()
        {
            var arrayList = new MyArrayList();
            arrayList.Add(5);
            arrayList.Add(2);
            arrayList.Add(1);

            arrayList.Clear();

            Assert.Empty(arrayList);
        }

        [Fact]
        public void Should_clone_array()
        {
            var arrayList = new MyArrayList();
            var clone = arrayList.Clone();
            arrayList.Add(5);
            Assert.NotEqual(arrayList, clone);
            arrayList.Remove(5);
            Assert.Equal(arrayList, clone);
        }

        [Fact]
        public void Should_check_if_contains_element()
        {
            var arrayList = new MyArrayList();
            arrayList.Add("test");
            arrayList.Add(5);

            var contains = arrayList.Contains("test");
            var dontContains = arrayList.Contains(1);

            Assert.True(contains);
            Assert.False(dontContains);
        }

        [Fact]
        public void Should_throw_ArgumentOutOfRangeException_when_calling_contains_with_null()
        {
            var arrayListTarget = new MyArrayList();
            Assert.Throws<ArgumentOutOfRangeException>(() => arrayListTarget.Contains(null));
        }

        [Fact]
        public void Should_copy_to()
        {
            var arrayListTarget = new MyArrayList()
            {
                0, 1, 2, 3, 4
            };

            var arraySource = new object[6]
            {
                5, "test", "test1", 10, 0, 2
            };

            arrayListTarget.CopyTo(arraySource, 2);

            var expected = new MyArrayList()
            {
                5, "test", 0, 1, 2, 3, 4
            };

            Assert.Equal(expected, arrayListTarget);
        }

        [Fact]
        public void Should_throw_ArgumentOutOfRangeException_when_calling_copy_to_with_negative_index()
        {
            var arrayList = new MyArrayList();
            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.CopyTo(new object[0], -1));
        }

        [Fact]
        public void Should_throw_ArgumentOutOfRangeException_when_calling_copy_to_with_null_array()
        {
            var arrayList = new MyArrayList();
            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.CopyTo(null, 0));
        }

        [Fact]
        public void Should_get_index_of_correctly()
        {
            var arrayListTarget = new MyArrayList()
            {
                5, "test", 10
            };

            var index = arrayListTarget.IndexOf("test");

            Assert.Equal(1, index);
        }

        [Fact]
        public void Should_not_get_index_of()
        {
            var arrayListTarget = new MyArrayList()
            {
                5, "test", 10
            };

            var index = arrayListTarget.IndexOf(0);

            Assert.Equal(-1, index);
        }

        [Fact]
        public void Should_throw_ArgumentOutOfRangeException_when_calling_index_of_with_null()
        {
            var arrayList = new MyArrayList();
            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.IndexOf(null));
        }

        [Fact]
        public void Should_insert_at_index()
        {
            var arrayList = new MyArrayList()
            {
                1, 2, "test", 3, 4, 5
            };

            arrayList.Insert(4, 7.2d);

            Assert.Equal(7.2d, arrayList[4]);
        }

        [Fact]
        public void Should_throw_ArgumentOutOfRangeException_when_calling_insert_at_with_negative_index()
        {
            var arrayList = new MyArrayList();
            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.Insert(-1, 1));
        }

        [Fact]
        public void Should_throw_ArgumentOutOfRangeException_when_calling_insert_at_with_null_value()
        {
            var arrayList = new MyArrayList();
            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.Insert(1, null));
        }

        [Fact]
        public void Should_remove_at_index()
        {
            var arrayList = new MyArrayList()
            {
                1, 2, "test", 3, 4, 5
            };

            arrayList.RemoveAt(2);

            Assert.Equal(3, arrayList[2]);
        }

        [Fact]
        public void Should_throw_ArgumentOutOfRangeException_when_calling_remove_at_with_negative_index()
        {
            var arrayList = new MyArrayList();
            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.Insert(-1, 1));
        }
    }
}
