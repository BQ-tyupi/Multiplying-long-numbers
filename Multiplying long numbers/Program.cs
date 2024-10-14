using System.Text;

namespace Multiplying_long_numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string a = MultiplyingLongNums("12341234312352576303195239857314023415462354", "3323464153253134352324357109351947524352345451554");
            Console.WriteLine(a);
        }

        static string MultiplyingLongNums(string num1, string num2)
        {
            string[] multiples = new string[num1.Length];
            int multiple1;
            string multiple2 = "", temp; 
            int carry = 0;
            int zeros = 0;
            for (int i  = num1.Length - 1; i >= 0; i--)
            {
                for (int j = num2.Length - 1; j >= 0; j--)
                {                    
                    multiple1 = (int.Parse(num1[i].ToString()) * int.Parse(num2[j].ToString()));
                   
                    temp = (multiple1 + carry).ToString();
                    if (temp.Length == 2)
                    {
                        multiple2 += temp[1].ToString();
                        carry = (int)char.GetNumericValue(temp[0]);
                    }
                    else
                    {
                        multiple2 += temp[0].ToString();
                        carry = 0;
                    }

                }
                if(carry != 0)
                {
                    multiple2 += carry.ToString();
                }
                char[] charArray = multiple2.ToCharArray();
                Array.Reverse(charArray);
                multiples[i] = new string(charArray) + new string('0', zeros);
                multiple2 = "";
                carry = 0;
                zeros++;
            }

            return AddLargeNumbers(multiples);
        }

        static string AddLargeNumbers(string[] numbers)
        {
            string totalSum = "0";  // Initialize the sum as string

            foreach (string number in numbers)
            {
                totalSum = AddTwoLargeNumbers(totalSum, number);
            }

            return totalSum;
        }

        static string AddTwoLargeNumbers(string num1, string num2)
        {
            // Ensure num1 is the longer number
            if (num1.Length < num2.Length)
            {
                (num1, num2) = (num2, num1);
            }

            // Reverse both strings to facilitate addition from least significant digit
            char[] num1Arr = num1.ToCharArray();
            char[] num2Arr = num2.ToCharArray();
            Array.Reverse(num1Arr);
            Array.Reverse(num2Arr);

            // Prepare for addition
            string result = "";
            int carry = 0;
            int maxLength = num1.Length;

            for (int i = 0; i < maxLength; i++)
            {
                int digit1 = num1Arr[i] - '0';  // Convert char to int
                int digit2 = (i < num2.Length) ? num2Arr[i] - '0' : 0;  // Get digit from num2 or 0 if out of range

                int sum = digit1 + digit2 + carry;
                carry = sum / 10;  // Calculate carry for next digit
                result += (sum % 10);  // Append current digit to result
            }

            // If there is a carry left, add it to result
            if (carry > 0)
            {
                result += carry;
            }

            // Reverse the result to get the correct order
            char[] resultArr = result.ToCharArray();
            Array.Reverse(resultArr);

            return new string(resultArr);
        }
    }
}
