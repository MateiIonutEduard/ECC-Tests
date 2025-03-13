using System;
using Eduard;

namespace ECC_Tests.Core
{
    /* This class is designed to manage a relatively small set of Weierstrass elliptic curves 
     * needed for testing operations with points in projective coordinates. 
    */
    public class EllipticCurveFactory
    {
        private EllipticCurve[] curves;

        public EllipticCurveFactory()
        {
            curves = new EllipticCurve[]
            {
                new EllipticCurve(new BigInteger("46105401198027654681634243335939378848360618916436153321066124718362967119871"),
                    new BigInteger("13943006676646306621094974592369253351532350327372449747797155047938080488539"),
                    new BigInteger("69031601562066225374130002653497935114879895810072505660147396962092181690817"),
                    new BigInteger("69031601562066225374130002653497935115248375216472169854035549992381177754647")
                ),
                new EllipticCurve(new BigInteger("42448638456328467212426617331286746148735621742462872558192463770348562046652"),
                    new BigInteger("43644619453595017303841503407364206904304399610433832956269904593381367511349"),
                    new BigInteger("76263212456168201990362411268346735195809001363208509457432290270048803066581"),
                    new BigInteger("76263212456168201990362411268346735196078657848254799319244818379987696210633")
                ),
               new EllipticCurve(new BigInteger("62403815898962523958532894660495931355222713229515257352789670329020312940546"),
                    new BigInteger("58070675192151164103222151392226663430615094410893191829222698033801511552573"),
                    new BigInteger("89104954876382337402063907362089498150618080955259183885221646288775546701637"),
                    new BigInteger("89104954876382337402063907362089498150377615948167288691804200554937080576381")
                ),
               new EllipticCurve(new BigInteger("39339516920862121827942459267809342388223907981308392205930961439017635978612"),
                    new BigInteger("52680040251483389591788620256794294039517044832177325167614328193547652148262"),
                    new BigInteger("104925872609419707401699452489815838805784788994523841545548898624239454621721"),
                    new BigInteger("104925872609419707401699452489815838805191005848627163739396196031807658042351")
                )
            };
        }

        public EllipticCurve this[int index]
        {
            get {
                if (index >= 0 && index < curves.Length) return curves[index];
                else throw new IndexOutOfRangeException("Index are out of range.");
            }
            set
            {
                if (index >= 0 && index < curves.Length) curves[index] = value;
                else
                {
                    if (index == curves.Length)
                    {
                        List<EllipticCurve> list = new List<EllipticCurve>();
                        list.AddRange(curves); list.Add(value);
                        curves = list.ToArray();
                    }
                    else throw new IndexOutOfRangeException($"Elliptic curves list does not have more than {curves.Length + 1} items.");
                }
            }
        }
    }
}
