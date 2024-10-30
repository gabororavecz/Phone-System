Module Module3
	Public Function calc_costofdata(ByVal data As Integer) As Decimal
		Dim num As Decimal
		num = If(data < 500, New Decimal(), New Decimal(CDbl((data - 500)) * 0.5))
		Return num
	End Function

	Public Function calc_costofmins(ByVal mins As Integer) As Decimal
		Dim num As Decimal
		num = If(mins < 500, New Decimal(), New Decimal(CDbl((mins - 500)) * 0.2))
		Return num
	End Function

	Public Function calc_costoftexts(ByVal texts As Integer) As Decimal
		Dim num As Decimal
		num = If(texts < 500, New Decimal(), New Decimal(CDbl((texts - 500)) * 0.1))
		Return num
	End Function

	Public Sub display_statement(ByVal index As Integer, ByVal month As Integer)
		Dim num As Decimal = New Decimal()
		Console.ForegroundColor = ConsoleColor.Blue
		Console.WriteLine("=================================================")
		Console.WriteLine(vbCrLf & "*************** Monthly Statement *************** " & vbCrLf)
		Console.WriteLine("=================================================")
		Console.ForegroundColor = ConsoleColor.White
		Dim str() As String = {Customers(index).FirstName, " ", Customers(index).Surname, "		Customer ID: ", Customers(index).CustomerID}
		Console.WriteLine(String.Concat(str))
		Console.WriteLine(String.Concat(Customers(index).Address, ", ", Customers(index).Postcode))
		Dim dateTime As System.DateTime = New System.DateTime(DateAndTime.Now.Year, month, 1)
		str = New String() {vbCrLf & "Mobile no. 	", Customers(index).TelephoneNumber, "	Statement Date	", dateTime.ToString("MMM"), " ", Nothing}
		Dim now As DateTime = DateAndTime.Now
		str(5) = now.Year
		Console.WriteLine(String.Concat(str))
		If Customers(index).Statement(month - 1).PlanType = "3G" Then
			num = New Decimal(CLng(10))
		ElseIf Customers(index).Statement(month - 1).PlanType = "4G" Then
			num = New Decimal(CLng(20))
		ElseIf Customers(index).Statement(month - 1).PlanType = "5G" Then
			num = New Decimal(CLng(30))
		End If
		Dim num1 As Decimal = calc_costofmins(Customers(index).Statement(month - 1).Mins)
		Dim num2 As Decimal = calc_costoftexts(Customers(index).Statement(month - 1).Texts)
		Dim num3 As Decimal = calc_costofdata(Customers(index).Statement(month - 1).Data)
		Dim num4 As Decimal = Decimal.Add(Decimal.Add(Decimal.Add(num, num1), num2), num3)
		Dim num5 As Decimal = New Decimal(Convert.ToDouble(num4) * 0.2)
		Dim num6 As Decimal = Decimal.Add(num4, num5)
		Console.WriteLine(String.Concat("" & vbCrLf & "Plan Type :	", Customers(index).Statement(month - 1).PlanType, "	", FormatCurrency(num)))
		Console.WriteLine(String.Concat("Mins Used :	", Customers(index).Statement(month - 1).Mins, "	", FormatCurrency(num1)))
		Console.WriteLine(String.Concat("Texts sent 	", Customers(index).Statement(month - 1).Texts, "	", FormatCurrency(num2)))
		Console.WriteLine(String.Concat("Data  Used (MB)	", Customers(index).Statement(month - 1).Data, "	", FormatCurrency(num3)))
		Console.WriteLine("==========================================")
		Console.WriteLine(String.Concat("Subtotal		", FormatCurrency(num4)))
		Console.WriteLine(String.Concat("VAT			", FormatCurrency(num5)))
		Console.ForegroundColor = ConsoleColor.Yellow
		Console.WriteLine(String.Concat("Total			", FormatCurrency(num6)))
		Console.ForegroundColor = ConsoleColor.Green
		Console.WriteLine("" & vbCrLf & "**************** END OF Statement ************" & vbCrLf & "")
		Console.ForegroundColor = ConsoleColor.Gray
		Console.Write("Press any key to return to Main Menu .....")
		Console.ReadKey()
	End Sub

	Public Sub SearchCustomer()
		Dim UserID As Integer = 0
		Dim check As Boolean = True
		Dim check1 As Boolean = False
		Do
			Try
				Console.Write("Type in Customer  ID ")
				UserID = Console.ReadLine()
				check = True
			Catch exception As Exception

				Console.ForegroundColor = ConsoleColor.Yellow
				Console.WriteLine("_Error! This is not a number. ")
				Console.ForegroundColor = ConsoleColor.Gray
				check = False

			End Try
		Loop While Not check
		Dim length As Integer = CInt(Customers.Length) - 1
		Dim num As Integer = 0
		While num <= length
			If (UserID <> Customers(num).CustomerID) Then
				num = num + 1
			Else
				check1 = True
				Exit While
			End If
		End While
		If (Not check1) Then
			Console.WriteLine(String.Concat("" & vbCrLf & "Customer ", UserID, " does not exist"))
		Else
			Console.WriteLine("" & vbCrLf & "Customer found")
			Dim str() As String = {Customers(num).CustomerID, " ", Customers(num).FirstName, " ", Customers(num).Surname, "	", Customers(num).TelephoneNumber, "" & vbCrLf & "" & vbCrLf & ""}
			Console.Write(String.Concat(str))
			Console.ForegroundColor = ConsoleColor.Green
			Console.WriteLine("Month	Plan	Mins	Texts	 Data (Mb)")
			Console.WriteLine("_________________________________________________" & vbCrLf & "" & vbCrLf & "")
			Console.ForegroundColor = ConsoleColor.White
			Dim num1 As Integer = 0
			Do
				str = New String() {num1 + 1, "	", Customers(num).Statement(num1).PlanType, "	", Customers(num).Statement(num1).Mins, "	", Customers(num).Statement(num1).Texts, "	", Customers(num).Statement(num1).Data}
				Console.WriteLine(String.Concat(str))
				num1 = num1 + 1
			Loop While num1 <= 11
		End If
		Console.Write(vbCrLf & " Press any key to return to Main Menu .....")
		Console.ReadKey()
	End Sub

	Public Sub DisplayCustomerBill()
		Dim num As Byte = 0
		Dim UserID As Integer = 0
		Dim check As Boolean = True
		Dim check1 As Boolean = False
		Do
			Try
				Console.Write("Type in Customer  ID ")
				UserID = Console.ReadLine()
				check = True
			Catch exception As Exception

				Console.ForegroundColor = ConsoleColor.Yellow
				Console.WriteLine("_Error! This is not a number. ")
				Console.ForegroundColor = ConsoleColor.Gray
				check = False

			End Try
		Loop While Not check
		Dim length As Integer = CInt(Customers.Length) - 1
		Dim num1 As Integer = 0
		While num1 <= length
			If (UserID <> Customers(num1).CustomerID) Then
				num1 = num1 + 1
			Else
				Console.WriteLine("" & vbCrLf & "Customer found")
				Dim str() As String = {Customers(num1).CustomerID, " ", Customers(num1).FirstName, " ", Customers(num1).Surname}
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
					Catch exception1 As System.Exception

						Console.ForegroundColor = ConsoleColor.Yellow
						Console.WriteLine("_Error! This is not a number or a valid month ... ")
						Console.ForegroundColor = ConsoleColor.Gray
						check = False

					End Try
					If (num <= 12) Then
						Continue Do
					End If
					Console.WriteLine()
					Console.ForegroundColor = ConsoleColor.Yellow
					Console.WriteLine(String.Concat("_", num, " is not a valid month ... "))
					Console.ForegroundColor = ConsoleColor.Gray
				Loop While Not check
			Loop While num > 12
			display_statement(num1, CInt(num))
		Else
			Console.WriteLine(String.Concat("No Customer found with CustomerID ", UserID))
			Console.Write("Press any key to return to Main Menu .....")
			Console.ReadKey()
		End If
	End Sub
End Module

