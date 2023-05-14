Public Class Form1
    Dim x = ""
    Dim a1 As String
    Dim a2, a3 As String
    Dim k = 0

    Private Sub ButtonNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click, Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button3.Click, Button10.Click, Button1.Click
        Dim b As Button = sender
        If k = 1 Then
            TextBox1.Text = ""
            TextBox2.Text = ""
            a1 = ""
            a2 = ""
            a3 = ""
            k = 0
        End If
        TextBox1.Text = TextBox1.Text + b.Text
        If (x = "") Then
            a1 &= b.Text
        Else
            a2 &= b.Text
            TextBox3.Text = a2
        End If
        a3 = ""

    End Sub



    Private Sub ButtonM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click, Button14.Click, Button13.Click, Button12.Click
        Dim mb As Button = sender
        If (k = 1) Then
            TextBox1.Text = ""
            TextBox1.Text = a1
            k = 0
        End If

        If x = "" Then
            x = mb.Text
            TextBox1.Text &= x
        End If
        If a1 <> "" And a2 = "" Then
            x = mb.Text
            If x <> "" Then
                TextBox1.Text = TextBox1.Text.Substring(0, Len(TextBox1.Text) - 1)
                TextBox1.Text &= x
                Exit Sub
            End If
        End If
        If a2 = "" Then
            Exit Sub
        End If

        Select Case x
            Case "+"
                a1 = Val(a1) + Val(a2)
            Case "-"
                a1 = Val(a1) - Val(a2)
            Case "*"
                a1 = Val(a1) * Val(a2)
            Case "/"
                If Val(a2) <> 0 Then
                    a1 = Val(a1) / Val(a2)
                End If

        End Select
        TextBox2.Text = a1
        a3 = a1
        x = mb.Text
        TextBox1.Text &= x

        a2 = ""
    End Sub



    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click

        Select Case x
            Case "+"
                a1 = Val(a1) + Val(a2)
            Case "-"
                a1 = Val(a1) - Val(a2)
            Case "*"
                a1 = Val(a1) * Val(a2)
            Case "/"
                If Val(a2) <> 0 Then
                    a1 = Val(a1) / Val(a2)
                End If
        End Select
        TextBox2.Text = a1
        x = ""
        a3 = a1
        a2 = ""
        k = 1
    End Sub
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        x = ""
        a1 = ""
        a2 = ""
        a3 = ""
        k = 0
    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Dim y As String
        y = e.KeyChar
        Select Case y
            Case 1
                Button1.PerformClick()
            Case 2
                Button2.PerformClick()
            Case 3
                Button3.PerformClick()
            Case 4
                Button4.PerformClick()
            Case 5
                Button5.PerformClick()
            Case 6
                Button6.PerformClick()
            Case 7
                Button7.PerformClick()
            Case 8
                Button8.PerformClick()
            Case 9
                Button9.PerformClick()
            Case 0
                Button10.PerformClick()
            Case "+"
                Button11.PerformClick()
            Case "-"
                Button12.PerformClick()
            Case "*"
                Button13.PerformClick()
            Case "/"
                Button14.PerformClick()
            Case "="
                Button15.PerformClick()
            Case Chr(13) 'Microsoft.VisualBasic.ChrW(Keys.Return) 
                Button15.PerformClick()
            Case Chr(8) 'Microsoft.VisualBasic.ChrW(Keys.Return) 
                Button17.PerformClick()
            Case "." 'Microsoft.VisualBasic.ChrW(Keys.Return) 
                Button16.PerformClick()
        End Select
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        If (TextBox1.Text.Substring(Len(TextBox1.Text) - 1, 1) = "+") Then
            x = ""
            TextBox1.Text = TextBox1.Text.Substring(0, Len(TextBox1.Text) - 1)
        ElseIf (TextBox1.Text.Substring(Len(TextBox1.Text) - 1, 1) = "-") Then
            x = ""
            TextBox1.Text = TextBox1.Text.Substring(0, Len(TextBox1.Text) - 1)
        ElseIf (TextBox1.Text.Substring(Len(TextBox1.Text) - 1, 1) = "*") Then
            x = ""
            TextBox1.Text = TextBox1.Text.Substring(0, Len(TextBox1.Text) - 1)
        ElseIf (TextBox1.Text.Substring(Len(TextBox1.Text) - 1, 1) = "/") Then
            x = ""
            TextBox1.Text = TextBox1.Text.Substring(0, Len(TextBox1.Text) - 1)
        ElseIf (TextBox1.Text.Substring(Len(TextBox1.Text) - 1, 1) = "0") Then
            TextBox1.Text = TextBox1.Text.Substring(0, Len(TextBox1.Text) - 1)
            a1 = TextBox1.Text
        ElseIf (TextBox1.Text.Substring(Len(TextBox1.Text) - 1, 1) = "1" Or "2" Or "3" Or "4" Or "5" Or "6" Or "7" Or "8" Or "9") Then
            If (x = "") Then
                TextBox1.Text = TextBox1.Text.Substring(0, Len(TextBox1.Text) - 1)
                a1 = TextBox1.Text
            Else
                TextBox1.Text = TextBox1.Text.Substring(0, Len(TextBox1.Text) - 1)
                TextBox3.Text = TextBox3.Text.Substring(0, Len(TextBox3.Text) - 1)
                a2 = TextBox3.Text
            End If
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        a1 = ""
        a2 = ""
        a3 = ""
    End Sub
End Class