Module Module1
    Public Customers As Customer()
    Public position As Integer

    Public Structure Customer
        Public CustomerID As Integer
        Public FirstName As String
        Public Surname As String
        Public Address As String
        Public Postcode As String
        Public DOB As DateTime
        Public TelephoneNumber As String
        Public Statement As Customer.MonthlyDetails()
        Public Structure MonthlyDetails
            Public Month As Integer
            Public PlanType As String
            Public Mins As Integer
            Public Texts As Integer
            Public Data As Integer
        End Structure
    End Structure
    Sub New()
        ReDim Customers(-1)
    End Sub
    Public Sub Main()
        Dim MenuOption As Integer = 0
        Dim check As Boolean = False
        LoadData()
        Do
            Console.Clear()
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine("*************************************************")
            Console.WriteLine("           GABOR PHONE SYSTEM          ")
            Console.WriteLine("*************************************************" & vbCrLf)
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine(" [1] Add New Customer Details")
            Console.WriteLine(" [2] Enter Data Usage Details")
            Console.WriteLine(" [3] Display All Customers")
            Console.WriteLine(" [4] Display User Bill")
            Console.WriteLine(" [5] Search for a Customer")
            Console.WriteLine(" [6] Complex Search")
            Console.WriteLine(" [7] Exit System")
            Do
                Try
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.Write(vbCrLf & " PLEASE MAKE A SELECTION: ")
                    Console.ForegroundColor = ConsoleColor.Yellow
                    MenuOption = Console.ReadLine()
                    check = True
                Catch exception As System.Exception

                    Console.ForegroundColor = ConsoleColor.Red
                    Console.WriteLine(" ### Error! This is not a number. ###")
                    Console.ForegroundColor = ConsoleColor.Yellow
                    check = False
                End Try
            Loop Until check = True

            Select Case MenuOption
                Case 1
                    AddCustomer()
                    Continue Do
                Case 2
                    InputUsage()
                    Continue Do
                Case 3
                    DisplayCustomers()
                    Continue Do
                Case 4
                    DisplayCustomerBill()
                    Continue Do
                Case 5
                    SearchCustomer()
                    Continue Do
                Case 6
                    ComplexSearch()
                    Continue Do
                Case 7
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.Write(" Press any key to exit... ")
                    Console.ReadKey()
                    SaveData()
                    Continue Do
            End Select

            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine("Invalid choice! press any key to continue...")
            Console.ForegroundColor = ConsoleColor.White
            Console.ReadKey()

        Loop While MenuOption <> 7

    End Sub
End Module

