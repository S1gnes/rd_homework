namespace LargeNumberExample
{
    public class LargeNumber
    {
        private List<int> digits;

        public LargeNumber(string value)
        {
            digits = new List<int>();
            foreach (char c in value)
            {
                if (char.IsDigit(c))
                {
                    digits.Add(int.Parse(c.ToString()));
                }
                else
                {
                    throw new ArgumentException("Invalid char in number.");
                }
            }
        }

        public static LargeNumber Add(LargeNumber a, LargeNumber b)
        {
            List<int> result = new List<int>();
            int carry = 0;
            int i = a.digits.Count - 1;
            int j = b.digits.Count - 1;
            while (i >= 0 || j >= 0 || carry > 0)
            {
                int sum = carry;
                if (i >= 0)
                {
                    sum += a.digits[i];
                    i--;
                }
                if (j >= 0)
                {
                    sum += b.digits[j];
                    j--;
                }
                result.Add(sum % 10);
                carry = sum / 10;
            }
            result.Reverse();
            return new LargeNumber(string.Join("", result));
        }

        public static LargeNumber Subtract(LargeNumber a, LargeNumber b)
        {
            if (a < b)
            {
                throw new ArgumentException("Cannot subtract larger number from smaller number.");
            }
            List<int> result = new List<int>();
            int borrow = 0;
            int i = a.digits.Count - 1;
            int j = b.digits.Count - 1;
            while (i >= 0 || j >= 0 || borrow > 0)
            {
                int diff = borrow;
                if (i >= 0)
                {
                    diff += a.digits[i];
                    i--;
                }
                if (j >= 0)
                {
                    diff -= b.digits[j];
                    j--;
                }
                if (diff < 0)
                {
                    diff += 10;
                    borrow = -1;
                }
                else
                {
                    borrow = 0;
                }
                result.Add(diff);
            }
            while (result.Count > 1 && result.Last() == 0)
            {
                result.RemoveAt(result.Count - 1);
            }
            result.Reverse();
            return new LargeNumber(string.Join("", result));
        }

        public static bool operator <(LargeNumber a, LargeNumber b)
        {
            if (a.digits.Count < b.digits.Count) return true;
            if (a.digits.Count > b.digits.Count) return false;
            for (int i = 0; i < a.digits.Count; i++)
            {
                if (a.digits[i] < b.digits[i]) return true;
                if (a.digits[i] > b.digits[i]) return false;
            }
            return false;
        }

        public static bool operator >(LargeNumber a, LargeNumber b)
        {
            return !(a < b || a == b);
        }

        public static bool operator ==(LargeNumber a, LargeNumber b)
        {
            return a.digits.SequenceEqual(b.digits);
        }

        public static bool operator !=(LargeNumber a, LargeNumber b)
        {
            return !(a == b);
        }


        public override string ToString()
        {
            return string.Join("", digits);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LargeNumber num1 = new LargeNumber("12345678901234567890");
            LargeNumber num2 = new LargeNumber("98765432109876543210");
        }
    }
}
