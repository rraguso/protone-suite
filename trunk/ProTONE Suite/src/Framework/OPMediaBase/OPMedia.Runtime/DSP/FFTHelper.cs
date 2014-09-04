using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPMedia.Runtime.DSP
{
    public static class FFTHelper
    {
        public static double[] TranslateFFTIntoBands(double[] fftData, double maxFq, int bandCount)
        {
            double[] bandFqs = new double[bandCount];
            double[] outData = new double[bandCount];
            bandFqs[0] = 20;

            double ratio = Math.Pow(maxFq / bandFqs[0], 1f / bandCount);

            int i = 1;
            int j = 0;

            for (; i < bandCount; i++)
                bandFqs[i] = ratio * bandFqs[i - 1];

            List<int[]> indexList = new List<int[]>();

            i = 0;
            for (; i < bandFqs.Length; i++)
            {
                double bandFq = bandFqs[i];
                List<int> idxs = new List<int>();

                for (; j < fftData.Length; j++)
                {
                    double fMax = (j + 1) * maxFq / fftData.Length;

                    if (fMax < bandFq)
                        idxs.Add(j);
                    else
                        break;
                }

                indexList.Add(idxs.ToArray());
            }

            Array.Clear(outData, 0, outData.Length);

            for (i = 0; i < bandCount; i++)
            {
                double data = 0;
                int[] idxs = indexList[i];

                if (idxs != null && idxs.Length > 0)
                {
                    foreach (int idx in idxs)
                    {
                        if (idx > 0 && idx < fftData.Length)
                            try
                            {
                                data += fftData[idx];
                            }
                            catch (Exception ex)
                            {
                                string s = ex.Message;
                            }

                            
                    }

                    data = data / idxs.Length;

                    try
                    {
                        outData[i] = data;
                    }
                    catch (Exception ex)
                    {
                        string s = ex.Message;
                    }

                }
                
            }

            return outData;
        }
    }
}
