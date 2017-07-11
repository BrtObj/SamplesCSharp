using System;

namespace PiCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberator = 1, denominator = 3, result = 0, carry = 0;
            int flag = 1, count = 0;
            int len = 0, i = 0;
            while (len == 0)
            {
                Console.Write("请输入小数点后的位数：");
                Int32.TryParse(Console.ReadLine(), out len);
            }
            len += 2;
            int[] temp = new int[len];
            int[] pi = new int[len];
            pi[1] = 2;
            temp[1] = 2;


            while (Convert.ToBoolean(flag) && (++count < 2147483647))  //int的最大值 2147483647  
            {
                carry = 0;
                for (i = len - 1; i > 0; i--)     //从低位到高位相乘  
                {
                    result = temp[i] * numberator + carry; //用每一位去乘，再加上进位  
                    temp[i] = result % 10;               //保存个数  
                    carry = result / 10;                 //进位  
                }

                carry = 0;
                for (i = 0; i < len; i++)                 //有高位到低位进行除法运算  
                {
                    result = temp[i] + carry * 10;         //当前位加上前一位的余数  
                    temp[i] = result / denominator;      //当前位的整数部分  
                    carry = result % denominator;        //当前位的余数，累加到下一位的运算  
                }
                flag = 0; //清除标志  

                for (i = len - 1; i > 0; i--)
                {
                    result = pi[i] + temp[i];            //将计算结果累加到result中  
                    pi[i] = result % 10;                 //保留一位  
                    pi[i - 1] += result / 10;              //向高位进位  
                    flag |= temp[i];                     //若temp中的数全为0,退出循环  
                }
                numberator++;       //累加分子  
                denominator += 2;   //累加分母  
            }

            Console.WriteLine("计算了" + count.ToString() + "次");
            Console.WriteLine("PI = 3.");
            for (int j = 2; j < pi.Length; j++)
            {
                if (j > 2 && (j - 2) % 10 == 0)
                    Console.Write(" ");
                if (j > 2 && (j - 2) % 50 == 0)
                    Console.Write("\n");
                Console.Write(pi[j].ToString());
            }

            Console.ReadKey();
        }
    }
}
