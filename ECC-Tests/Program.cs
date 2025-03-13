using ECC_Tests.Core;
using ECC_Tests.Utils;
using Eduard;
using System.Diagnostics;
using System.Security.Cryptography;
using ECPoint = Eduard.ECPoint;

namespace ECC_Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rand = RandomNumberGenerator.Create();
            EllipticCurveFactory factory = new EllipticCurveFactory();
            EllipticCurve curve = factory[0];

            ECPoint basePoint = curve.BasePoint;
            JacobianPoint jacobianPoint = curve.ToJacobian(basePoint);
            ModifiedJacobianPoint modifiedJacobianPoint =  curve.ToModifiedJacobian(basePoint);

            var clock = new Stopwatch();
            BigInteger k = BigInteger.Next(rand, 1, curve.order - 1);

            clock.Start();
            var final = Multiply(curve, k, modifiedJacobianPoint);
            clock.Stop();

            Console.WriteLine($"total time for modified Jacobian projective coordinates multiplication: {clock.Elapsed.Milliseconds} ms");
            ECPoint affinePoint1 = curve.ToAffine(final);

            clock.Restart();
            var final2 = Multiply(curve, k, jacobianPoint);
            clock.Stop();

            Console.WriteLine($"total time for Jacobian projective coordinates multiplication: {clock.Elapsed.Milliseconds} ms");
            ECPoint affinePoint2 = curve.ToAffine(final2);

            clock.Restart();
            ECPoint baseKPoint = ECMath.Multiply(curve, k, basePoint);
            clock.Stop();

            Console.WriteLine($"total time for affine coordinates multiplication: {clock.Elapsed.Milliseconds} ms");
        }

        static ModifiedJacobianPoint Multiply(EllipticCurve curve, BigInteger sk, ModifiedJacobianPoint point)
        {
            ModifiedJacobianPoint res = ModifiedJacobianPoint.POINT_INFINITY;
            ModifiedJacobianPoint basePoint = point;

            for(int k = 0; k < sk.GetBits(); k++)
            {
                if(sk.TestBit(k))
                    res = ModifiedJacobianMath.Add(curve, res, basePoint);

                basePoint = ModifiedJacobianMath.Doubling(curve, basePoint);
            }

            return res;
        }

        static JacobianPoint Multiply(EllipticCurve curve, BigInteger sk, JacobianPoint point)
        {
            JacobianPoint res = JacobianPoint.POINT_INFINITY;
            JacobianPoint basePoint = point;

            for (int k = 0; k < sk.GetBits(); k++)
            {
                if (sk.TestBit(k))
                    res = JacobianMath.Add(curve, res, basePoint);

                basePoint = JacobianMath.Doubling(curve, basePoint);
            }

            return res;
        }
    }
}
