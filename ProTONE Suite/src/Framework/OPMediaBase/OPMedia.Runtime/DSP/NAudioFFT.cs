using System;

namespace OPMedia.Runtime.DSP
{
    public static class NAudioFFT
    {
        public static void Forward(double[] realIn, double[] realOut)
        {
            if (realIn.Length != realOut.Length)
                throw new Exception("realOut must have same size as realIn");

            double[] data = new double[2 * realIn.Length];

            Array.Clear(realOut, 0, realIn.Length);
            Array.Clear(data, 0, 2 * realIn.Length);

            for (int i = 0; i < realIn.Length; i++)
                data[2 * i] = realIn[i];

            doFFT(data, true);

            for (int i = 0; i < realIn.Length; i++)
            {
                double re = data[2 * i];
                double im = data[2 * i + 1];
                realOut[i] = Math.Sqrt(re * re + im * im);
            }
        }

        private static void doFFT(double[] data, bool forward)
        {
            int n, i, i1, j, k, i2, l, l1, l2;
            double c1, c2, tx, ty, t1, t2, u1, u2, z;

            // Calculate the number of points
            int m = (int)(Math.Log(data.Length,2.0)-0.05);
            n = data.Length;
            // check all are valid
            if (((n & (n - 1)) != 0) || (n != (2<<m))) // checks nn is a power of 2 in 2's complement format
                throw new Exception("realIn has data length: " + n + ", which is not a power of 2");
            n /= 2;

            //Console.WriteLine("Length {0} {1}",n,m);

            // Do the bit reversal
            i2 = n >> 1;
            j = 0;
            for (i = 0; i < n - 1; i++)
            {
                if (i < j)
                {
                    tx = data[i * 2];
                    ty = data[i * 2 + 1];
                    data[i * 2] = data[j * 2];
                    data[i * 2 + 1] = data[j * 2 + 1];
                    data[j * 2] = tx;
                    data[j * 2 + 1] = ty;
                }
                k = i2;

                while (k <= j)
                {
                    j -= k;
                    k >>= 1;
                }
                j += k;
            }

            // Compute the FFT 
            c1 = -1.0f;
            c2 = 0.0f;
            l2 = 1;
            for (l = 0; l < m; l++)
            {
                l1 = l2;
                l2 <<= 1;
                u1 = 1.0f;
                u2 = 0.0f;
                for (j = 0; j < l1; j++)
                {
                    for (i = j; i < n; i += l2)
                    {
                        i1 = i + l1;
                        t1 = u1 * data[i1 * 2] - u2 * data[i1 * 2 + 1];
                        t2 = u1 * data[i1 * 2 + 1] + u2 * data[i1 * 2];
                        data[i1 * 2] = data[i * 2] - t1;
                        data[i1 * 2 + 1] = data[i * 2 + 1] - t2;
                        data[i * 2] += t1;
                        data[i * 2 + 1] += t2;
                    }
                    z = u1 * c1 - u2 * c2;
                    u2 = u1 * c2 + u2 * c1;
                    u1 = z;
                }
                c2 = (float)Math.Sqrt((1.0f - c1) / 2.0f);
                if (!forward)
                    c2 = -c2;
                c1 = (float)Math.Sqrt((1.0f + c1) / 2.0f);
            }

            // Scaling for inverse transform 
            if (!forward)
            {
                for (i = 0; i < n; i++)
                {
                    data[i * 2] /= n;
                    data[i * 2 + 1] /= n;
                }
            }
        }
    }
}
