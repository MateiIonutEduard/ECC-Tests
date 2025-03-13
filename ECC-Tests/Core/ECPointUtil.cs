using System;
using Eduard;

namespace ECC_Tests.Core
{
    /* This class is a utility for converting projective points to affine form and vice versa. */
    public static class ECPointUtil
    {
        public static ECPoint ToAffine(this EllipticCurve curve, JacobianPoint jacobianPoint)
        {
            BigInteger p = curve.field;
            BigInteger Z2 = (jacobianPoint.z * jacobianPoint.z) % p;

            BigInteger Z3 = (Z2 * jacobianPoint.z) % p;
            BigInteger X = (jacobianPoint.x * Z2.Inverse(p)) % p;

            BigInteger Y = (jacobianPoint.y * Z3.Inverse(p)) % p;
            return new ECPoint(X, Y);
        }

        public static ECPoint ToAffine(this EllipticCurve curve, JacobianChudnovskyPoint jacobianPoint)
        {
            BigInteger p = curve.field;
            BigInteger X = (jacobianPoint.x * jacobianPoint.z2.Inverse(p)) % p;

            BigInteger Y = (jacobianPoint.y * jacobianPoint.z3.Inverse(p)) % p;
            return new ECPoint(X, Y);
        }

        public static ECPoint ToAffine(this EllipticCurve curve, ModifiedJacobianPoint jacobianPoint)
        {
            BigInteger p = curve.field;
            BigInteger Z2 = (jacobianPoint.z * jacobianPoint.z) % p;

            BigInteger Z3 = (Z2 * jacobianPoint.z) % p;
            BigInteger X = (jacobianPoint.x * Z2.Inverse(p)) % p;

            BigInteger Y = (jacobianPoint.y * Z3.Inverse(p)) % p;
            return new ECPoint(X, Y);
        }

        public static JacobianPoint ToJacobian(this EllipticCurve curve, ECPoint affinePoint)
        {
            JacobianPoint jacobianPoint = new JacobianPoint
            {
                x = affinePoint.GetAffineX(),
                y = affinePoint.GetAffineY(),
                z = 1
            };

            return jacobianPoint;
        }

        public static JacobianChudnovskyPoint ToJacobianChudnovsky(this EllipticCurve curve, ECPoint affinePoint)
        {
            JacobianChudnovskyPoint jacobianChudnovskyPoint = new JacobianChudnovskyPoint
            {
                x = affinePoint.GetAffineX(),
                y = affinePoint.GetAffineY(),
                z = 1,
                z2 = 1,
                z3 = 1
            };

            return jacobianChudnovskyPoint;
        }

        public static ModifiedJacobianPoint ToModifiedJacobian(this EllipticCurve curve, ECPoint affinePoint)
        {
            ModifiedJacobianPoint jacobianPoint = new ModifiedJacobianPoint
            {
                x = affinePoint.GetAffineX(),
                y = affinePoint.GetAffineY(),
                aZ4 = curve.a,
                z = 1
            };

            return jacobianPoint;
        }
    }
}
