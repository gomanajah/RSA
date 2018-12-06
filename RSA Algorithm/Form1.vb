Imports System.Numerics
Public Class Form1
    'Generater keys
    Dim q As Integer
    Dim p As Integer
    Dim n As Integer
    Dim z As Integer
    Dim ee As System.Numerics.BigInteger = 0
    'Generater keys
    'Decryption
    Dim d2 As System.Numerics.BigInteger = 0
    Dim n2 As Integer
    'Decryption
    'Encryption
    Dim e1 As System.Numerics.BigInteger = 0
    Dim n1 As Integer
    'Encryption
    'Randome d
    Dim dd As System.Numerics.BigInteger = 0
    Dim ddd
    Dim max As Integer
    Dim min As Integer
    'Randome d
    'Ascii to Decimal,Decimal To hex 'Encryption
    Dim Ciphertext As String
    'Ascii to Decimal,Decimal To hex 'Encryption

    '==============================================Key Selection TAPControl================================================
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calc_NandZ.Click
        If Not IsNumeric(Enter_p.Text) Then
            MsgBox("Enter (p) as a Number", , "Alert")
        Else
            If Not IsNumeric(Enter_q.Text) Then
                MsgBox("Enter (q) as a Number", , "Alert")
            Else
                If Enter_p.Text = Enter_q.Text Then
                    MsgBox("p and q must be not equal!", , "Alert")
                Else
                    Dim i, j As Integer
                    Dim t As Boolean
                    i = Enter_p.Text
                    t = True
                    For j = 2 To (i - 1)
                        If i Mod j = 0 Then
                            t = False
                            Exit For
                        End If
                    Next j
                    If t Then
                        Dim ii, jj As Integer
                        Dim tt As Boolean
                        ii = Enter_q.Text
                        tt = True
                        For jj = 2 To (ii - 1)
                            If ii Mod jj = 0 Then
                                tt = False
                                Exit For
                            End If
                        Next jj
                        If tt Then
                            p = Enter_p.Text
                            q = Enter_q.Text
                            n = p * q
                            z = (p - 1) * (q - 1)
                            Label4.Visible = True
                            Label5.Visible = True
                            Label_n1.Visible = True
                            Label_z.Visible = True
                            Enter_e.Enabled = True
                            Label_n1.Text = n
                            Label_z.Text = z
                            PuKey_n.Text = n
                            PrKey_n.Text = n
                            If n < 127 Then
                                MsgBox("(n) should be greater than 127, Please try again!", , "Error")
                                n = 0
                                z = 0
                                Enter_p.Text = ""
                                Enter_q.Text = ""
                                Label4.Visible = False
                                Label5.Visible = False
                                Label_n1.Visible = False
                                Label_z.Visible = False
                            Else
                                CalcKeys.Enabled = True
                            End If
                        Else
                            MsgBox(ii & "  (q) is not a prime Number", , "Error")
                        End If
                    Else
                        MsgBox(i & "  (p) is not a prime Number", , "Error")
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcKeys.Click
        ee = Enter_e.Text
        If Not IsNumeric(Enter_e.Text) Then
            MsgBox("Enter (e) as a Number", , "Alert")
        Else
            If ee > n Then
                MsgBox("(e) should be smaller than (n) ", , "Alert")
            Else
                Dim j As Integer
                Dim t As Boolean
                t = True
                For j = 2 To (ee - 1)
                    If ee Mod j = 0 Then
                        t = False
                        Exit For
                    End If
                Next j
                If t Then
                    'Randome d
                    Do While ddd <> 1
                        Static staticRandomGenerator As New System.Random
                        max += 1
                        dd = staticRandomGenerator.Next(If(min > max, max, min), If(min > max, min, max))
                        ddd = ee * dd Mod z
                    Loop
                    'Randome d 
                    Label_n3.Text = n
                    Label_n2.Text = n
                    Label_e.Text = (ee).ToString("N0")
                    Label_d.Text = (dd).ToString("N0")
                    PuKey_e.Text = (ee).ToString("N0")
                    PrKey_d.Text = (dd).ToString("N0")
                Else
                    MsgBox(" (e) is not a prime Number", , "Error")
                End If
            End If
        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Kclear.Click
        CalcKeys.Enabled = False
        Label4.Visible = False
        Label5.Visible = False
        Enter_e.Enabled = False
        Enter_p.Text = ""
        Enter_q.Text = ""
        Enter_e.Text = ""
        Label_n1.Text = ""
        Label_z.Text = ""
        Label_e.Text = ""
        Label_d.Text = ""
        Label_n3.Text = ""
        Label_n2.Text = ""
        p = 0
        q = 0
        n = 0
        z = 0
        ee = 0
        dd = 0
        ddd = 0
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Kexit.Click
        Application.Exit()
    End Sub
    '==============================================Key Selection TAPControl================================================
    '==============================================Encryption TAPControl================================================
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Copye.Click
        If Not IsNumeric(PuKey_e.Text) = Nothing Then
            Clipboard.SetText(PuKey_e.Text)
        Else
            MsgBox("No key is selected to copy", , "Alert")
        End If
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Encrypt.Click
        If Not IsNumeric(PuKey_e.Text) Or Not IsNumeric(PuKey_n.Text) Or EnterPT.Text = Nothing Then
            MsgBox("Please, Enter public key e,n and plaintext", , "Alert")
        Else
            e1 = PuKey_e.Text
            n1 = PuKey_n.Text
            'Ascii to Decimal 'Encryption
            Dim plaintext As String
            plaintext = EnterPT.Text
            Ciphertext = plaintext.Select(Function(t) (BigInteger.Pow(Asc(t), e1) Mod n1).ToString()).Aggregate(Function(t1, t2) t1 & "," & t2)
            CT_int.Text = Ciphertext
            'Ascii to Decimal 'Encryption

            'Decimal To hex
            Dim input = Ciphertext
            Dim CiphertextHex = String.Join("t", input.Split(","c).Select(Function(x) Convert.ToInt32(x).ToString("x")))            'Replace 0 to any char you want and chane x small to get capital chars
            CT_hex.Text = CiphertextHex

            Dim CiphertextHexc = String.Join("t", input.Split(","c).Select(Function(x) Convert.ToInt32(x).ToString("x")))            'Replace 0 to any char you want and chane x small to get capital chars
            EnterCT.Text = CiphertextHexc
            'Decimal To hex
        End If
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Eclear.Click
        e1 = 0
        n1 = 0
        EnterPT.Text = ""
        CT_int.Text = ""
        CT_hex.Text = ""
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Eexit.Click
        Application.Exit()
    End Sub
    '==============================================Encryption TAPControl================================================
    '==============================================Decryption TAPControl================================================
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Copyd.Click
        If Not IsNumeric(PrKey_d.Text) = Nothing Then
            Clipboard.SetText(PrKey_d.Text)
        Else
            MsgBox("No key is selected to copy", , "Alert")
        End If
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Decrypt.Click
        If Not IsNumeric(PrKey_d.Text) Or Not IsNumeric(PrKey_n.Text) Or EnterCT.Text = Nothing Then
            MsgBox("Please, Enter private key d,n and ciphertext(in hex)", , "Alert")
        Else
            d2 = PrKey_d.Text
            n2 = PrKey_n.Text
            'Hex to Decimal
            Dim CiphertextDec = EnterCT.Text
            Dim CiphertextDec1 = String.Join(",", CiphertextDec.Split("t"c).Select(Function(x) Convert.ToInt32(x, 16).ToString()))
            PT_int.Text = CiphertextDec1
            'Hex to Decimal

            'Decimal to Ascii 'Decryption
            Dim CiphertexttoAscii As String = PT_int.Text
            Dim Parts As String() = CiphertexttoAscii.Split(","c)
            For Each Part As String In Parts
                Dim Plaintext1 As BigInteger = (BigInteger.Pow((Part), d2) Mod n2)
                Dim PlaintextAscii As Char = Chr(Plaintext1)
                ShowPT.Text = ShowPT.Text + PlaintextAscii 'To show Ascii
            Next
            'Decimal to Ascii 'Decryption
        End If
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dclear.Click
        EnterCT.Text = ""
        PT_int.Text = ""
        ShowPT.Text = ""
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dexit.Click
        Application.Exit()
    End Sub

End Class