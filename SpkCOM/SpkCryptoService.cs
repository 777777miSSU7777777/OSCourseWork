using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SpkCOM
{
    [Guid("05e0b6d9-8726-44ed-af18-4b301e31ca1b"),
    ClassInterface(ClassInterfaceType.None),
    ComSourceInterfaces(typeof(IEvents))]
    public class SpkCryptoService : ICryptoService
    {
        private int[] ParseKey(string _key)
        {
            int[] key = new int[_key.Length];
            string[] keyParts = _key.Split(' ');

            for (int i = 0; i < key.Length; i++)
            {
                key[i] = Convert.ToInt32(keyParts[i]);
            }

            return key;
        }

        public string Encrypt(string input, string _key)
        {
            int[] key = ParseKey(_key);

            for (int i = 0; i < input.Length % key.Length; i++)
                input += " ";

            string result = "";

            var counter = 0;

            var height = input.Length / key.Length;
            var width = key.Length;

            char[][] tab = new char[height][];
            for (int i = 0; i < height; i++)
            {
                tab[i] = new char[width];
            }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    tab[j][i] = input[counter++];
                }
            }

            char[][] res_tab = new char[height][];
            for (int i = 0; i < height; i++)
            {
                res_tab[i] = new char[width];
            }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == key[j] - 1)
                    {
                        for (int k = 0; k < height; k++)
                        {
                            res_tab[k][key[i] - 1] = tab[k][i];
                        }
                    }
                }
            }



            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    result += res_tab[i][j];
                }
            }

            return result;
        }

        public string Decrypt(string input, string _key)
        {
            int[] key = ParseKey(_key);

            string result = "";

            var counter = 0;

            var height = input.Length / key.Length;
            var width = key.Length;

            char[][] tab = new char[height][];
            for (int i = 0; i < height; i++)
            {
                tab[i] = new char[width];
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    tab[i][j] = input[counter++];
                }
            }

            char[][] res_tab = new char[height][];
            for (int i = 0; i < height; i++)
            {
                res_tab[i] = new char[width];
            }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == key[j] - 1)
                    {
                        for (int k = 0; k < height; k++)
                        {
                            res_tab[k][i] = tab[k][key[i] - 1];
                        }
                    }
                }
            }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    result += res_tab[j][i];
                }
            }

            return result;
        }
    }
}
