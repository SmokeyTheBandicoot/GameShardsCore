Option Strict On

Imports System.Math
Imports NCalc

Namespace AdvancedMath

  '''
  '''Sum (Summation, Sommatoria)
  '''Use Like This: Summation("2 * [a] + 3 * [b] + [x]", 0, 2, New List(Of String) = {"a", "b"}.ToList, New List(Of Double) = {2, 3}.ToList)
  '''x is the main argument (ie: Sum that goes from 0 to 2)
  '''This Will produce:
  '''2 * 2 + 3 * 3 + 0 (For x = Start) + 2 * 2 + 3 * 3 + 1 (For x = 1) + 2 * 2 + 3 * 3 + 2 (For x = End) = 42
  Public Shared Function Summation(Byval Expr, Byval Start as Integer, Byval End As Integer, Byval ParamRef As List(Of String), Byval ParamVal As List(Of Double)) As Double
    
    'Initilization
    
    Dim Sum As Double 'automatically initialized to 0
    Dim e As New Expression(Expr)
    
    'Parameter calculation
    For y As Integer = ParamRef.Count - 1
      e.Parameters(ParamRef(y)) = ParamVal(y)
    Next
    
    'Sum Calculation
    For x As Integer = Start to End
      e.Parameters("[x]") = x
      Sum += e.Evaluate()
    Next
    
    Return Sum
  End Function
  
  '''
  '''Prod (Multiplication, Produttoria)
  '''Use Like This: Multiplication("2 * [a] + 3 * [b] + [x]", 0, 2, New List(Of String) = {"a", "b"}.ToList, New List(Of Double) = {2, 3}.ToList)
  '''x is the main argument (ie: Prod that goes from 0 to 2)
  '''This Will produce:
  '''(2 * 2 + 3 * 3 + 0) (For x = Start) * (2 * 2 + 3 * 3 + 1) (For x = 1) * (2 * 2 + 3 * 3 + 2) (For x = End) = 2730
  Public Shared Function Multiplication(Byval Expr, Byval Start as Integer, Byval End As Integer, Byval ParamRef As List(Of String), Byval ParamVal As List(Of Double)) As Double
    
    'Initilization
    
    Dim Prod As Double 'automatically initialized to 0
    Dim e As New Expression(Expr)
    
    'Parameter calculation
    For y As Integer = ParamRef.Count - 1
      e.Parameters(ParamRef(y)) = ParamVal(y)
    Next
    
    'Prod Calculation
    For x As Integer = Start to End
      e.Parameters("[x]") = x
      Prod *= e.Evaluate()
    Next
    
    Return Prod
  End Function
End Namespace
