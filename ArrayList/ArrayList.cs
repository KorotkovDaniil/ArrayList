using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class ArrayList
    {
        public int Lenght { get; private set; }
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Lenght)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[index];
            }
            set
            {
                if (index < 0 || index >= Lenght)
                {
                    throw new IndexOutOfRangeException();
                }
                _array[index] = value;
            }
        }

        private int[] _array;
        public ArrayList()
        {
            _array = new int[5];
            Lenght = 0;
        }

        public ArrayList(int value)
        {
            _array = new int[5];
            Lenght = 1;
            _array[0] = value;
        }

        public ArrayList(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                _array = new int[5];
                Lenght = 0;
            }
            else
            {
                _array = array;
                Lenght = array.Length;
                UpSize();
            }
        }
        public void AddToTheEnd(int value)
        {
            if (Lenght >= _array.Length)
            {
                UpSize();
            }
            _array[Lenght] = value;
            Lenght++;
        }

        public void AddToTheBegining(int value)
        {
            if (Lenght >= _array.Length)
            {
                UpSize();
            }
            MoveStepRight(0);
            _array[0] = value;
            Lenght++;
        }

        public void Insert(int index, int value)
        {
            if (Lenght >= _array.Length)
            {
                UpSize();
            }
            MoveStepRight(index);
            _array[index] = value;
            Lenght++;
        }

        public void RemoveLast()
        {
            if (Lenght == 0)
            {
                throw new Exception("Empty arraylist");
            }
            if (Lenght <= _array.Length / 2)
            {
                DownSize();
            }
            Lenght--;
        }

        public void RemoveFirst()
        {
            if (Lenght == 0)
            {
                throw new Exception("Empty arraylist");
            }
            if (Lenght <= _array.Length / 2)
            {
                DownSize();
            }
            MoveStepLeft(0);
            Lenght--;
        }
        public void RemoveByIndex(int index)
        {
            MoveStepLeft(index);
            Lenght--;
        }
        private void UpSize()
        {
            int newLength = (int)(_array.Length * 1.5d + 1);
            int[] newArray = new int[newLength];
            Copy(newArray);
        }

        private void DownSize()
        {
            int newLength = (int)(_array.Length / 3.0d + 1);
            int[] newArray = new int[newLength];
            Copy(newArray);
        }

        private void Copy(int[] newArray)
        {
            for (int i = 0; i < Lenght; i++)
            {
                newArray[i] = _array[i];
            }
            _array = newArray;
        }
        private void MoveStepLeft(int index)
        {
            int[] newArray = new int[_array.Length - 1];
            for (int i = 0; i < index; i++)
            {
                newArray[i] = _array[i];
            }
            for (int i = index; i < _array.Length - 1; i++)
            {
                newArray[i] = _array[i + 1];
            }
            _array = newArray;
        }
        private void MoveStepRight(int index)
        {
            Lenght++;
            int[] newArray = new int[Lenght];
            for (int i = 0; i < index; i++)
            {
                newArray[i] = _array[i];
            }
            for (int i = index; i < Lenght; i++)
            {
                newArray[i + 1] = _array[i];
            }
            _array = newArray;
        }
    }
}

