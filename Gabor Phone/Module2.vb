Imports Microsoft.VisualBasic.MyServices
Imports Gabor_Phone.My
Module Module2
    Sub New()
    End Sub

    Public Sub AddCustomer()
        Dim check As Boolean = True
        position = UBound(Customers) + 1
        ReDim Preserve Customers(position)
        ReDim Preserve Customers(position).Statement(11)
        Console.ForegroundColor = ConsoleColor.Cyan
        Console.WriteLine("*************************************************")
        Console.WriteLine("                  NEW CUSTOMER                   ")
        Console.WriteLine("*************************************************" & vbCrLf)
        Console.ForegroundColor = ConsoleColor.Yellow
        Do
            Try
                Console.Write("Customer ID Number: ")
                Customers(position).CustomerID = Console.ReadLine()
                check = True
            Catch exception As System.Exception
                Console.ForegroundColor = ConsoleColor.Cyan
                Console.WriteLine("Error! This is not a valid number. ")
                Console.ForegroundColor = ConsoleColor.Gray
                check = False
            End Try
        Loop While Not check
        Do
            Console.Write("" & vbCrLf & "Customer First  Name: ")
            Customers(position).FirstName = StrConv(Console.ReadLine(), VbStrConv.ProperCase)

            If (String.IsNullOrEmpty(Customers(position).FirstName)) Then
                Console.ForegroundColor = ConsoleColor.Yellow
                Console.WriteLine("First Name cannot be blank...")
                Console.ForegroundColor = ConsoleColor.Gray
            End If
        Loop While String.IsNullOrEmpty(Customers(position).FirstName)

        Do
            Console.Write("" & vbCrLf & "Customer Surname: ")
            Customers(position).Surname = StrConv(Console.ReadLine(), VbStrConv.ProperCase)
            If (String.IsNullOrEmpty(Customers(position).Surname)) Then
                Console.ForegroundColor = ConsoleColor.Yellow
                Console.WriteLine("Surname cannot be blank...")
                Console.ForegroundColor = ConsoleColor.Gray
            End If

        Loop While String.IsNullOrEmpty(Customers(position).Surname)
        Console.Write("Address : ")
        Customers(position).Address = Console.ReadLine()
        Console.Write("Post Code: ")
        Customers(position).Postcode = Console.ReadLine().ToUpper()
        Do
            Try
                Console.Write("DoB [dd/mm/yyyy] : ")
                Customers(position).DOB = Console.ReadLine()
                check = True
            Catch exception1 As System.Exception

                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("Error! This is not a valid date. Press any key to continue")
                Console.ForegroundColor = ConsoleColor.Gray
                check = False

            End Try
        Loop While check = False
        Console.Write("Customer Mobile no. ")
        Customers(position).TelephoneNumber = Console.ReadLine()
    End Sub

    Public Sub ComplexSearch()
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine("*************************************************")
        Console.WriteLine("                 COMPLEX SEARCH               ")
        Console.WriteLine("*************************************************" & vbCrLf)
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine(" Search for Employees by Surname and age " & vbCrLf)
        Console.Write("Enter beginning letter ")
        Dim chr As Char = Console.ReadLine()
        Console.Write("Enter end letter ")
        Dim chr1 As Char = Console.ReadLine()
        Console.Write("Enter age limit  ")
        Dim UserInputID As Integer = Console.ReadLine()
        Dim length As Integer = CInt(Customers.Length) - 1
        Dim num As Integer = 0
        Do
            Dim now As DateTime = DateAndTime.Now
            Dim year As Integer = now.Year - Customers(num).DOB.Year
            If Left(Customers(num).Surname, 1) >= chr And Left(Customers(num).Surname, 1) <= chr1 And year <= UserInputID Then
                Dim str() As String = {Customers(num).CustomerID, ",", Customers(num).FirstName, " ", Customers(num).Surname, " ", Customers(num).DOB}
                Console.WriteLine(String.Concat(str))
            End If
            num = num + 1
        Loop While num <= length
        Console.WriteLine("" & vbCrLf & "Press any key to continue...")
        Console.ReadKey()
    End Sub
    Public Sub InputUsage()
        Dim num As Byte = 0
        Dim check As Boolean = True
        Dim check1 As Boolean = False
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine("*************************************************")
        Console.WriteLine("                 INPUT DATA USAGE                 ")
        Console.WriteLine("*************************************************" & vbCrLf)
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.Write("Type in Customer  ID ")
        Dim UserInputID As Integer = Console.ReadLine()
        Dim length As Integer = CInt(Customers.Length) - 1
        Dim num1 As Integer = 0
        While num1 <= length
            If (UserInputID <> Customers(num1).CustomerID) Then
                num1 = num1 + 1
            Else
                Console.WriteLine("" & vbCrLf & "Customer found")
                Dim str() As String = {Customers(num1).CustomerID, " ", Customers(num1).FirstName, " ", Customers(num1).FirstName}
                Console.Write(String.Concat(str))
                check1 = True
                Exit While
            End If
        End While
        If (check1) Then
            Do
                Do
                    Try
                        Console.Write("" & vbCrLf & "Which Month [1-12] ")
                        num = Console.ReadLine()
                        check = True
                    Catch exception As System.Exception

                        Console.ForegroundColor = ConsoleColor.Yellow
                        Console.WriteLine("Error! This is not a number or a valid month ... ")
                        Console.ForegroundColor = ConsoleColor.Gray
                        check = False

                    End Try
                    If (num <= 12) Then
                        Continue Do
                    End If
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Yellow
                    Console.WriteLine(String.Concat("", num, " is not a valid month ... "))
                    Console.ForegroundColor = ConsoleColor.Gray
                Loop While Not check
            Loop While num > 12
            Customers(num1).Statement(num - 1).Month = num
            Do
                Console.Write("" & vbCrLf & "Plan Type [3G or 4G or 5G] ")
                Customers(num1).Statement(num - 1).PlanType = Console.ReadLine().ToUpper()
            Loop Until Customers(num1).Statement(num - 1).PlanType = "3G" Or Customers(num1).Statement(num - 1).PlanType = "4G" Or Customers(num1).Statement(num - 1).PlanType = "5G"
            Do
                Try
                    Console.Write("Minuites Used ")
                    Customers(num1).Statement(num - 1).Mins = Console.ReadLine()
                    check = True
                Catch exception1 As System.Exception

                    Console.ForegroundColor = ConsoleColor.Yellow
                    Console.WriteLine("Error! This is not a Number. Press any key to continue")
                    Console.ForegroundColor = ConsoleColor.Gray
                    check = False

                End Try
            Loop While Not check
            Do
                Try
                    Console.Write("Texts sent ")
                    Customers(num1).Statement(num - 1).Texts = Console.ReadLine()
                    check = True
                Catch exception2 As System.Exception

                    Console.ForegroundColor = ConsoleColor.Yellow
                    Console.WriteLine("Error! This is not a Number. Press any key to continue")
                    Console.ForegroundColor = ConsoleColor.Gray
                    check = False

                End Try
            Loop While Not check
            Do
                Try
                    Console.Write("Data Used ")
                    Customers(num1).Statement(num - 1).Data = Console.ReadLine()
                    check = True
                Catch exception3 As System.Exception

                    Console.ForegroundColor = ConsoleColor.Yellow
                    Console.WriteLine("Error! This is not a Number. Press any key to continue")
                    Console.ForegroundColor = ConsoleColor.Gray
                    check = False

                End Try
            Loop While Not check
            display_statement(num1, CInt(num))
        Else
            Console.WriteLine(String.Concat(" No Customer found with CustomerID ", UserInputID))
            Console.Write(" Press any key to return to Main Menu .....")
            Console.ReadKey()
        End If
    End Sub
    Public Sub DisplayCustomers()
        Console.Clear()
        Dim i As Integer
        Dim check As Boolean = False
        Dim length As Integer = CInt(Customers.Length)
        Do
            check = False
            Dim num As Integer = length - 1
            For i = 1 To num Step 1
                If (Customers(i - 1).CustomerID > Customers(i).CustomerID) Then
                    Dim _customer As Customer = Customers(i - 1)
                    Customers(i - 1) = Customers(i)
                    Customers(i) = _customer
                    check = True
                End If
            Next

        Loop While check
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine("*************************************************")
        Console.WriteLine("               CUSTOMER LIST                ")
        Console.WriteLine("*************************************************" & vbCrLf)
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("Customer Id	CustomerName	DOB                 ")
        Console.WriteLine("_________________________________________________" & vbCrLf & vbCrLf)
        Console.ForegroundColor = ConsoleColor.White
        Dim num1 As Integer = UBound(Customers, 1)
        i = 0
        Do
            Dim str() As String = {Customers(i).CustomerID, "		", Customers(i).FirstName, " ", Customers(i).Surname, "	", Strings.FormatDateTime(Customers(i).DOB, DateFormat.ShortDate)}
            Console.WriteLine(String.Concat(str))
            i = i + 1
        Loop While i <= num1
        Console.Write(vbCrLf & " Press any key  to continue.... ")
        Console.ReadKey()
    End Sub
    Public Sub SaveData()
        Dim str As String()
        Dim streamWriter As System.IO.StreamWriter = New System.IO.StreamWriter("data.csv")
        Dim length As Integer = CInt(Customers.Length) - 1
        Dim num As Integer = 0
        Do
            Dim str1 As String = ""
            Dim num1 As Integer = 0
            Do
                str = New String() {str1, ",", Customers(num).Statement(num1).PlanType, ",", Customers(num).Statement(num1).Mins, ",", Customers(num).Statement(num1).Texts, ",", Customers(num).Statement(num1).Data}
                str1 = String.Concat(str)
                num1 = num1 + 1
            Loop While num1 <= 11
            str = New String() {Customers(num).CustomerID, ",", Customers(num).FirstName, ",", Customers(num).Surname, ",", Customers(num).DOB, ",", Customers(num).Address, ",", Customers(num).Postcode, ",", Customers(num).TelephoneNumber, str1}
            streamWriter.WriteLine(String.Concat(str))
            num = num + 1
        Loop While num <= length
        streamWriter.Close()
    End Sub
    Public Sub LoadData()
        Dim fileSystem As FileSystemProxy = MyProject.Computer.FileSystem
        Dim strArrays() As String = {","}
        Dim textFieldParser As Microsoft.VisualBasic.FileIO.TextFieldParser = fileSystem.OpenTextFieldParser("data.csv", strArrays)
        While Not textFieldParser.EndOfData
            Dim strArrays1 As String() = textFieldParser.ReadFields()
            position = UBound(Customers) + 1

            ReDim Preserve Customers(position)
            ReDim Preserve Customers(position).Statement(11)

            Customers(position).CustomerID = strArrays1(0)
            Customers(position).FirstName = strArrays1(1)
            Customers(position).Surname = strArrays1(2)
            Customers(position).DOB = strArrays1(3)
            Customers(position).Address = strArrays1(4)
            Customers(position).Postcode = strArrays1(5)
            Customers(position).TelephoneNumber = strArrays1(6)
            Dim num As Integer = 0
            Do
                Customers(position).Statement(num).PlanType = strArrays1(7 + num * 4)
                Customers(position).Statement(num).Mins = strArrays1(8 + num * 4)
                Customers(position).Statement(num).Texts = strArrays1(9 + num * 4)
                Customers(position).Statement(num).Data = strArrays1(10 + num * 4)
                num = num + 1
            Loop While num <= 11
        End While
    End Sub
End Module

