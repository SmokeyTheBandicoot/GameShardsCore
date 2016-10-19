Imports System.Math
Namespace Constants
    Public Class Geometry
        Public Const Rad2Deg As Double = 180.0 / Math.PI
        Public Const Deg2Rad As Double = Math.PI / 180.0
        Public Const Pi As Double = Math.PI
        Public Const GoldenRatio As Double = 1.6180339887498949 '(1+Sqrt(5))/2
    End Class

    Public Class MathConst
        Public Const E As Double = Math.E
        Public Const Pi As Double = Math.PI
    End Class

    Public Class Phisics
        ''' <summary>
        ''' Speed of Light
        ''' </summary>
        ''' <remarks></remarks>
        Public Const SpeedOfLight As Double = 299792458

        ''' <summary>
        ''' Planck constant (in Joules / Second)
        ''' </summary>
        ''' <remarks></remarks>
        Public Const PlanckConstant As Double = 6.67E-34

        ''' <summary>
        ''' Planck constant (in eV / Second)
        ''' </summary>
        ''' <remarks></remarks>
        Public Const PlanckConstanteVs As Double = 0.0000000000000041356692


        Public Const PlanckHBar As Double = 1.0545727E-34
        Public Const PlanckHBareVs As Double = 0.0000000000000006582121
        Public Const Gravitation As Double = 0.0000000000667259
        Public Const Boltzman As Double = 1.380658E-23
        Public Const BoltzmaneVK As Double = 0.00008617385
        Public Const MolarGas As Double = 8.31451
        Public Const AvogadrosNumber As Double = 6.0221E+23
        Public Const ChargeOfElectron As Double = 1.60217733E-19
        Public Const PermeabilityOfVacuumMu0 As Double = 4 * PI * (10 ^ -7)
        Public Const PermittivityOfVacuumE0 As Double = 0.000000000008854187817
        Public Const CoulombK0 As Double = 8987552000.0
        Public Const Faraday As Double = 96485.309
        Public Const MassOfElectron As Double = 9.1093897E-31
        Public Const MassOfProton As Double = 1.6726231E-27
        Public Const MassOfNeutron As Double = 1.67749286E-27
        Public Const AtomicMassUnit As Double = 1.6605402E-27
        Public Const StefanBoltzman As Double = 0.0000000567051
        Public Const Rydlberg As Double = 10973731.534
        Public Const BohrMagneton As Double = 9.2740154
        Public Const FluxQuantum As Double = 0.000000000000002067834
        Public Const StandardAtmospherePascal As Double = 101325
        Public Const WienDisplacement As Double = 0.002897756
        Public Const GravityAcceleration As Double = 9.80665
        Public Const ElementaryChargesInACoulomb As Double = 6.25E+18
        Public Const SpeedOfSoundInAir As Double = 331
    End Class
End Namespace
