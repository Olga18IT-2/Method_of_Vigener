using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Метод_Виженера
{
    class Program
    {
        public static void Show_matr(char[,] tabl, int size, string alph)
        {
            Console.Write("  ");
            for(int i=0; i< alph.Length; i++) Console.Write(alph[i] + " ");
            Console.WriteLine();
            for (int i = 0; i < alph.Length; i++) 
                Console.Write("--"); 
            Console.WriteLine("--");
            
            for (int i = 0; i < size; i++)
            {  
                for (int j = 0; j < size; j++)
                {   
                    if (j == 0) 
                        Console.Write(alph[i]+"|");
                    Console.Write(tabl[i, j] + " ");
                }

                Console.WriteLine();
            }   

            Console.WriteLine();
        }
        
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight); 
            // задаем максимальны размер консоли

            string alph = "ABCDEFGHIJKLMNOPQRSTUVWXYZАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789";
            int size = alph.Length;
            char[,] tabl = new char[size, size];
            // заполняем таблицу
            for (int i = 0; i < size; i++) 
                for (int j = 0; j < size; j++) 
                    tabl[i, j] = alph[(i + j) % size];
            Show_matr(tabl, size, alph); // вывод таблицы

            Console.Write("\nВведите сообщение для шифрования:");     
            string M = Console.ReadLine();
            Console.Write("Введите ключ для шифрования:");          
            string K = Console.ReadLine();
            
            M = M.ToUpper(); 
            K = K.ToUpper(); 
            string C = ""; 

            for (int i=0; i<M.Length; i++)
            {
                char char_i = M[i];  // буква сообщения
                char char_j = K[i % K.Length]; // буква ключа          
                int ind_1 = alph.IndexOf(char_i); // индекс буквы сообщения в таблицы (номер строки)
                int ind_2 = alph.IndexOf(char_j); // индекс буквы ключа в таблицы (номер столбца)
                C = C + tabl[ind_1, ind_2];    
                Console.WriteLine("[" + char_i + ", " + char_j + "] = " + tabl[ind_1, ind_2]); // промежуточный результат
            }
            Console.WriteLine("Ответ: "+C);

            Console.Write("\nВведите сообщение для расшифрования:");       C = Console.ReadLine();
            Console.Write("Введите ключ для расшифрования:");            K = Console.ReadLine();
            C = C.ToUpper(); K = K.ToUpper(); // переводим к заглавным буквам

            M = "";
            for(int j=0; j<C.Length; j++)
            {   char char_j = K[j % K.Length];    // буква ключа
                int ind_2 = alph.IndexOf(char_j); // индекс буквы ключа в таблицы (номер столбца)
                for (int i = 0; i < size; i++)    // проходим по всем строкам
                    if (tabl[i, ind_2] == (char)C[j])  
                    // сравниваем буквы в столбце ind_2 в нужной буквой сообщения (C[j])
                    {   M = M + alph[i];
                        Console.WriteLine("[ ? , " + char_j + "] = " + C[j] + " --->  ? = " + alph[i]);
                        break; 
                    } 
            }
            Console.WriteLine("Ответ: " + M);
            Console.ReadLine();
        }
    }
}