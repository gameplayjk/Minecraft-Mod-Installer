﻿
Imports System, System.IO, System.Collections.Generic
Imports System.Drawing, System.Drawing.Drawing2D
Imports System.ComponentModel, System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging

'------------------
'Creator: aeonhack
'Site: *********
'Created: 08/02/2011
'Changed: 12/06/2011
'Version: 1.5.4
'------------------







Class ChromeThemeContainer
    Inherits ThemeContainer154

    Sub New()
        TransparencyKey = Color.Fuchsia
        BackColor = Color.White
        Font = New Font("Segoe UI", 9)
        SetColor("Title color", Color.Black)
        SetColor("X-color", 90, 90, 90)
        SetColor("X-ellipse", 114, 114, 114)
    End Sub

    Dim TitleColor, Xcolor, Xellipse As Color
    Protected Overrides Sub ColorHook()
        TitleColor = GetColor("Title color")
        Xcolor = GetColor("X-color")
        Xellipse = GetColor("X-ellipse")
    End Sub

    Dim X, Y As Integer

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        X = e.Location.X : Y = e.Location.Y
        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
        If New Rectangle(Width - 22, 5, 15, 15).Contains(New Point(X, Y)) Then
            FindForm.Close()
        End If
        MyBase.OnMouseClick(e)
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)
        DrawCorners(Color.Fuchsia)
        DrawCorners(Color.Fuchsia, 1, 0, Width - 2, Height)
        DrawCorners(Color.Fuchsia, 0, 1, Width, Height - 2)
        DrawCorners(Color.Fuchsia, 2, 0, Width - 4, Height)
        DrawCorners(Color.Fuchsia, 0, 2, Width, Height - 4)

        G.SmoothingMode = SmoothingMode.HighQuality
        If New Rectangle(Width - 22, 5, 15, 15).Contains(New Point(X, Y)) Then
            G.FillEllipse(New SolidBrush(Xellipse), New Rectangle(Width - 24, 6, 16, 16))
            G.DrawString("r", New Font("Webdings", 8), New SolidBrush(BackColor), New Point(Width - 23, 5))
        Else
            G.DrawString("r", New Font("Webdings", 8), New SolidBrush(Xcolor), New Point(Width - 23, 5))
        End If

        DrawText(New SolidBrush(TitleColor), New Point(8, 7))
    End Sub
End Class

Class ChromeButton
    Inherits ThemeControl154

    Sub New()
        Font = New Font("Segoe UI", 9)
        SetColor("Gradient top normal", 237, 237, 237)
        SetColor("Gradient top over", 242, 242, 242)
        SetColor("Gradient top down", 235, 235, 235)
        SetColor("Gradient bottom normal", 230, 230, 230)
        SetColor("Gradient bottom over", 235, 235, 235)
        SetColor("Gradient bottom down", 223, 223, 223)
        SetColor("Border", 167, 167, 167)
        SetColor("Text normal", 60, 60, 60)
        SetColor("Text down/over", 20, 20, 20)
        SetColor("Text disabled", Color.Gray)
    End Sub

    Dim GTN, GTO, GTD, GBN, GBO, GBD, Bo, TN, TD, TDO As Color
    Protected Overrides Sub ColorHook()
        GTN = GetColor("Gradient top normal")
        GTO = GetColor("Gradient top over")
        GTD = GetColor("Gradient top down")
        GBN = GetColor("Gradient bottom normal")
        GBO = GetColor("Gradient bottom over")
        GBD = GetColor("Gradient bottom down")
        Bo = GetColor("Border")
        TN = GetColor("Text normal")
        TDO = GetColor("Text down/over")
        TD = GetColor("Text disabled")
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)
        Dim LGB As LinearGradientBrush
        G.SmoothingMode = SmoothingMode.HighQuality


        Select Case State
            Case MouseState.None
                LGB = New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), GTN, GBN, 90.0F)
            Case MouseState.Over
                LGB = New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), GTO, GBO, 90.0F)
            Case Else
                LGB = New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), GTD, GBD, 90.0F)
        End Select

        If Not Enabled Then
            LGB = New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), GTN, GBN, 90.0F)
        End If

        Dim buttonpath As GraphicsPath = CreateRound(Rectangle.Round(LGB.Rectangle), 3)
        G.FillPath(LGB, CreateRound(Rectangle.Round(LGB.Rectangle), 3))
        If Not Enabled Then G.FillPath(New SolidBrush(Color.FromArgb(50, Color.White)), CreateRound(Rectangle.Round(LGB.Rectangle), 3))
        G.SetClip(buttonpath)
        LGB = New LinearGradientBrush(New Rectangle(0, 0, Width, Height / 6), Color.FromArgb(80, Color.White), Color.Transparent, 90.0F)
        G.FillRectangle(LGB, Rectangle.Round(LGB.Rectangle))



        G.ResetClip()
        G.DrawPath(New Pen(Bo), buttonpath)

        If Enabled Then
            Select Case State
                Case MouseState.None
                    DrawText(New SolidBrush(TN), HorizontalAlignment.Center, 1, 0)
                Case Else
                    DrawText(New SolidBrush(TDO), HorizontalAlignment.Center, 1, 0)
            End Select
        Else
            DrawText(New SolidBrush(TD), HorizontalAlignment.Center, 1, 0)
        End If
    End Sub
End Class

Class ChromeCheckbox

    Inherits ThemeControl154

    Sub New()
        LockHeight = 17
        Font = New Font("Segoe UI", 9)
        SetColor("Gradient top normal", 237, 237, 237)
        SetColor("Gradient top over", 242, 242, 242)
        SetColor("Gradient top down", 235, 235, 235)
        SetColor("Gradient bottom normal", 230, 230, 230)
        SetColor("Gradient bottom over", 235, 235, 235)
        SetColor("Gradient bottom down", 223, 223, 223)
        SetColor("Border", 167, 167, 167)
        SetColor("Text", 60, 60, 60)
        Width = 160
    End Sub

    Private X As Integer
    Dim GTN, GTO, GTD, GBN, GBO, GBD, Bo, T As Color
    Protected Overrides Sub ColorHook()
        GTN = GetColor("Gradient top normal")
        GTO = GetColor("Gradient top over")
        GTD = GetColor("Gradient top down")
        GBN = GetColor("Gradient bottom normal")
        GBO = GetColor("Gradient bottom over")
        GBD = GetColor("Gradient bottom down")
        Bo = GetColor("Border")
        T = GetColor("Text")
    End Sub

    Protected Overrides Sub OnMouseMove(e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        X = e.Location.X
        Invalidate()
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)
        Dim LGB As LinearGradientBrush
        G.SmoothingMode = SmoothingMode.HighQuality
        Select Case State
            Case MouseState.None
                LGB = New LinearGradientBrush(New Rectangle(0, 0, 14, 14), GTN, GBN, 90.0F)
            Case MouseState.Over
                LGB = New LinearGradientBrush(New Rectangle(0, 0, 14, 14), GTO, GBO, 90.0F)
            Case Else
                LGB = New LinearGradientBrush(New Rectangle(0, 0, 14, 14), GTD, GBD, 90.0F)
        End Select
        Dim buttonpath As GraphicsPath = CreateRound(Rectangle.Round(LGB.Rectangle), 5)
        G.FillPath(LGB, CreateRound(Rectangle.Round(LGB.Rectangle), 3))
        G.SetClip(buttonpath)
        LGB = New LinearGradientBrush(New Rectangle(0, 0, 14, 5), Color.FromArgb(150, Color.White), Color.Transparent, 90.0F)
        G.FillRectangle(LGB, Rectangle.Round(LGB.Rectangle))
        G.ResetClip()
        G.DrawPath(New Pen(Bo), buttonpath)

        DrawText(New SolidBrush(T), 17, -2)


        If Checked Then
            Dim check As Image = Image.FromStream(New System.IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAsAAAAJCAYAAADkZNYtAAAABGdBTUEAALGOfPtRkwAAACBjSFJNAACHDwAAjA8AAP1SAACBQAAAfXkAAOmLAAA85QAAGcxzPIV3AAAKOWlDQ1BQaG90b3Nob3AgSUNDIHByb2ZpbGUAAEjHnZZ3VFTXFofPvXd6oc0wAlKG3rvAANJ7k15FYZgZYCgDDjM0sSGiAhFFRJoiSFDEgNFQJFZEsRAUVLAHJAgoMRhFVCxvRtaLrqy89/Ly++Osb+2z97n77L3PWhcAkqcvl5cGSwGQyhPwgzyc6RGRUXTsAIABHmCAKQBMVka6X7B7CBDJy82FniFyAl8EAfB6WLwCcNPQM4BOB/+fpFnpfIHomAARm7M5GSwRF4g4JUuQLrbPipgalyxmGCVmvihBEcuJOWGRDT77LLKjmNmpPLaIxTmns1PZYu4V8bZMIUfEiK+ICzO5nCwR3xKxRoowlSviN+LYVA4zAwAUSWwXcFiJIjYRMYkfEuQi4uUA4EgJX3HcVyzgZAvEl3JJS8/hcxMSBXQdli7d1NqaQffkZKVwBALDACYrmcln013SUtOZvBwAFu/8WTLi2tJFRbY0tba0NDQzMv2qUP91829K3NtFehn4uWcQrf+L7a/80hoAYMyJarPziy2uCoDOLQDI3fti0zgAgKSobx3Xv7oPTTwviQJBuo2xcVZWlhGXwzISF/QP/U+Hv6GvvmckPu6P8tBdOfFMYYqALq4bKy0lTcinZ6QzWRy64Z+H+B8H/nUeBkGceA6fwxNFhImmjMtLELWbx+YKuGk8Opf3n5r4D8P+pMW5FonS+BFQY4yA1HUqQH7tBygKESDR+8Vd/6NvvvgwIH554SqTi3P/7zf9Z8Gl4iWDm/A5ziUohM4S8jMX98TPEqABAUgCKpAHykAd6ABDYAasgC1wBG7AG/iDEBAJVgMWSASpgA+yQB7YBApBMdgJ9oBqUAcaQTNoBcdBJzgFzoNL4Bq4AW6D+2AUTIBnYBa8BgsQBGEhMkSB5CEVSBPSh8wgBmQPuUG+UBAUCcVCCRAPEkJ50GaoGCqDqqF6qBn6HjoJnYeuQIPQXWgMmoZ+h97BCEyCqbASrAUbwwzYCfaBQ+BVcAK8Bs6FC+AdcCXcAB+FO+Dz8DX4NjwKP4PnEIAQERqiihgiDMQF8UeikHiEj6xHipAKpAFpRbqRPuQmMorMIG9RGBQFRUcZomxRnqhQFAu1BrUeVYKqRh1GdaB6UTdRY6hZ1Ec0Ga2I1kfboL3QEegEdBa6EF2BbkK3oy+ib6Mn0K8xGAwNo42xwnhiIjFJmLWYEsw+TBvmHGYQM46Zw2Kx8lh9rB3WH8vECrCF2CrsUexZ7BB2AvsGR8Sp4Mxw7rgoHA+Xj6vAHcGdwQ3hJnELeCm8Jt4G749n43PwpfhGfDf+On4Cv0CQJmgT7AghhCTCJkIloZVwkfCA8JJIJKoRrYmBRC5xI7GSeIx4mThGfEuSIemRXEjRJCFpB+kQ6RzpLuklmUzWIjuSo8gC8g5yM/kC+RH5jQRFwkjCS4ItsUGiRqJDYkjiuSReUlPSSXK1ZK5kheQJyeuSM1J4KS0pFymm1HqpGqmTUiNSc9IUaVNpf+lU6RLpI9JXpKdksDJaMm4ybJkCmYMyF2TGKQhFneJCYVE2UxopFykTVAxVm+pFTaIWU7+jDlBnZWVkl8mGyWbL1sielh2lITQtmhcthVZKO04bpr1borTEaQlnyfYlrUuGlszLLZVzlOPIFcm1yd2WeydPl3eTT5bfJd8p/1ABpaCnEKiQpbBf4aLCzFLqUtulrKVFS48vvacIK+opBimuVTyo2K84p6Ss5KGUrlSldEFpRpmm7KicpFyufEZ5WoWiYq/CVSlXOavylC5Ld6Kn0CvpvfRZVUVVT1Whar3qgOqCmrZaqFq+WpvaQ3WCOkM9Xr1cvUd9VkNFw08jT6NF454mXpOhmai5V7NPc15LWytca6tWp9aUtpy2l3audov2Ax2yjoPOGp0GnVu6GF2GbrLuPt0berCehV6iXo3edX1Y31Kfq79Pf9AAbWBtwDNoMBgxJBk6GWYathiOGdGMfI3yjTqNnhtrGEcZ7zLuM/5oYmGSYtJoct9UxtTbNN+02/R3Mz0zllmN2S1zsrm7+QbzLvMXy/SXcZbtX3bHgmLhZ7HVosfig6WVJd+y1XLaSsMq1qrWaoRBZQQwShiXrdHWztYbrE9Zv7WxtBHYHLf5zdbQNtn2iO3Ucu3lnOWNy8ft1OyYdvV2o/Z0+1j7A/ajDqoOTIcGh8eO6o5sxybHSSddpySno07PnU2c+c7tzvMuNi7rXM65Iq4erkWuA24ybqFu1W6P3NXcE9xb3Gc9LDzWepzzRHv6eO7yHPFS8mJ5NXvNelt5r/Pu9SH5BPtU+zz21fPl+3b7wX7efrv9HqzQXMFb0ekP/L38d/s/DNAOWBPwYyAmMCCwJvBJkGlQXlBfMCU4JvhI8OsQ55DSkPuhOqHC0J4wybDosOaw+XDX8LLw0QjjiHUR1yIVIrmRXVHYqLCopqi5lW4r96yciLaILoweXqW9KnvVldUKq1NWn46RjGHGnIhFx4bHHol9z/RnNjDn4rziauNmWS6svaxnbEd2OXuaY8cp40zG28WXxU8l2CXsTphOdEisSJzhunCruS+SPJPqkuaT/ZMPJX9KCU9pS8Wlxqae5Mnwknm9acpp2WmD6frphemja2zW7Fkzy/fhN2VAGasyugRU0c9Uv1BHuEU4lmmfWZP5Jiss60S2dDYvuz9HL2d7zmSue+63a1FrWWt78lTzNuWNrXNaV78eWh+3vmeD+oaCDRMbPTYe3kTYlLzpp3yT/LL8V5vDN3cXKBVsLBjf4rGlpVCikF84stV2a9021DbutoHt5turtn8sYhddLTYprih+X8IqufqN6TeV33zaEb9joNSydP9OzE7ezuFdDrsOl0mX5ZaN7/bb3VFOLy8qf7UnZs+VimUVdXsJe4V7Ryt9K7uqNKp2Vr2vTqy+XeNc01arWLu9dn4fe9/Qfsf9rXVKdcV17w5wD9yp96jvaNBqqDiIOZh58EljWGPft4xvm5sUmoqbPhziHRo9HHS4t9mqufmI4pHSFrhF2DJ9NProje9cv+tqNWytb6O1FR8Dx4THnn4f+/3wcZ/jPScYJ1p/0Pyhtp3SXtQBdeR0zHYmdo52RXYNnvQ+2dNt293+o9GPh06pnqo5LXu69AzhTMGZT2dzz86dSz83cz7h/HhPTM/9CxEXbvUG9g5c9Ll4+ZL7pQt9Tn1nL9tdPnXF5srJq4yrndcsr3X0W/S3/2TxU/uA5UDHdavrXTesb3QPLh88M+QwdP6m681Lt7xuXbu94vbgcOjwnZHokdE77DtTd1PuvriXeW/h/sYH6AdFD6UeVjxSfNTws+7PbaOWo6fHXMf6Hwc/vj/OGn/2S8Yv7ycKnpCfVEyqTDZPmU2dmnafvvF05dOJZ+nPFmYKf5X+tfa5zvMffnP8rX82YnbiBf/Fp99LXsq/PPRq2aueuYC5R69TXy/MF72Rf3P4LeNt37vwd5MLWe+x7ys/6H7o/ujz8cGn1E+f/gUDmPP8usTo0wAAAAlwSFlzAAALEQAACxEBf2RfkQAAAK1JREFUKFN10D0OhSAQBGAOp2D8u4CNHY0kegFPYaSyM+EQFhY2NsTGcJ3xQbEvxlBMQsg3SxYGgMWitUbbtjiO40fAotBaizzPIYQI8YUo7rqO4DAM78nneYYLH2MMOOchdV3DOffH4zgiyzJM04T7vlFVFeF1XWkI27YNaZpSiqKgs1KKIC0opXwVfLksS1zX9cW+Nc9zeDpJkpBlWV7w83X7vqNpGvR9/4EePztSBhXQfRi8AAAAAElFTkSuQmCC")))
            G.DrawImage(check, New Rectangle(2, 3, check.Width, check.Height))
        End If
    End Sub

    Private _Checked As Boolean
    Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        _Checked = Not _Checked
        RaiseEvent CheckedChanged(Me)
        MyBase.OnMouseDown(e)
    End Sub

    Event CheckedChanged(ByVal sender As Object)

End Class

<DefaultEvent("CheckedChanged")> _
Class ChromeRadioButton
    Inherits ThemeControl154

    Sub New()
        Font = New Font("Segoe UI", 9)
        LockHeight = 17
        SetColor("Text", 60, 60, 60)
        SetColor("Gradient top", 237, 237, 237)
        SetColor("Gradient bottom", 230, 230, 230)
        SetColor("Borders", 167, 167, 167)
        SetColor("Bullet", 100, 100, 100)
        Width = 180
    End Sub

    Private X As Integer
    Private TextColor, G1, G2, Bo, Bb As Color

    Protected Overrides Sub ColorHook()
        TextColor = GetColor("Text")
        G1 = GetColor("Gradient top")
        G2 = GetColor("Gradient bottom")
        Bb = GetColor("Bullet")
        Bo = GetColor("Borders")
    End Sub

    Protected Overrides Sub OnMouseMove(e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        X = e.Location.X
        Invalidate()
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.HighQuality
        If _Checked Then
            Dim LGB As New LinearGradientBrush(New Rectangle(New Point(0, 0), New Size(14, 14)), G1, G2, 90.0F)
            G.FillEllipse(LGB, New Rectangle(New Point(0, 0), New Size(14, 14)))
        Else
            Dim LGB As New LinearGradientBrush(New Rectangle(New Point(0, 0), New Size(14, 16)), G1, G2, 90.0F)
            G.FillEllipse(LGB, New Rectangle(New Point(0, 0), New Size(14, 14)))
        End If

        If State = MouseState.Over And X < 15 Then
            Dim SB As New SolidBrush(Color.FromArgb(10, Color.Black))
            G.FillEllipse(SB, New Rectangle(New Point(0, 0), New Size(14, 14)))
        ElseIf State = MouseState.Down And X < 15 Then
            Dim SB As New SolidBrush(Color.FromArgb(20, Color.Black))
            G.FillEllipse(SB, New Rectangle(New Point(0, 0), New Size(14, 14)))
        End If

        Dim P As New GraphicsPath()
        P.AddEllipse(New Rectangle(0, 0, 14, 14))
        G.SetClip(P)

        Dim LLGGBB As New LinearGradientBrush(New Rectangle(0, 0, 14, 5), Color.FromArgb(150, Color.White), Color.Transparent, 90.0F)
        G.FillRectangle(LLGGBB, LLGGBB.Rectangle)

        G.ResetClip()

        G.DrawEllipse(New Pen(Bo), New Rectangle(New Point(0, 0), New Size(14, 14)))

        If _Checked Then
            Dim LGB As New SolidBrush(Bb)
            G.FillEllipse(LGB, New Rectangle(New Point(4, 4), New Size(6, 6)))
        End If

        DrawText(New SolidBrush(TextColor), HorizontalAlignment.Left, 17, -2)
    End Sub

    Private _Field As Integer = 16
    Property Field() As Integer
        Get
            Return _Field
        End Get
        Set(ByVal value As Integer)
            If value < 4 Then Return
            _Field = value
            LockHeight = value
            Invalidate()
        End Set
    End Property

    Private _Checked As Boolean
    Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            InvalidateControls()
            RaiseEvent CheckedChanged(Me)
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        If Not _Checked Then Checked = True
        MyBase.OnMouseDown(e)
    End Sub

    Event CheckedChanged(ByVal sender As Object)

    Protected Overrides Sub OnCreation()
        InvalidateControls()
    End Sub

    Private Sub InvalidateControls()
        If Not IsHandleCreated OrElse Not _Checked Then Return

        For Each C As Control In Parent.Controls
            If C IsNot Me AndAlso TypeOf C Is ChromeRadioButton Then
                DirectCast(C, ChromeRadioButton).Checked = False
            End If
        Next
    End Sub

End Class

Class ChromeSeparator
    Inherits ThemeControl154

    Sub New()
        LockHeight = 1
        BackColor = Color.FromArgb(238, 238, 238)
    End Sub

    Protected Overrides Sub ColorHook()

    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)
    End Sub
End Class

Class ChromeTabcontrol
    Inherits TabControl

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
        DoubleBuffered = True
        SizeMode = TabSizeMode.Fixed
        ItemSize = New Size(30, 115)
    End Sub
    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Alignment = TabAlignment.Left
    End Sub

    Dim C1 As Color = Color.FromArgb(78, 87, 100)
    Property SquareColor As Color
        Get
            Return C1
        End Get
        Set(ByVal value As Color)
            C1 = value
            Invalidate()
        End Set
    End Property

    Dim OB As Boolean = False
    Property ShowOuterBorders As Boolean
        Get
            Return OB
        End Get
        Set(ByVal value As Boolean)
            OB = value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Try : SelectedTab.BackColor = Color.White : Catch : End Try
        G.Clear(Color.White)
        For i = 0 To TabCount - 1
            Dim x2 As Rectangle = New Rectangle(New Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), New Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1))
            Dim textrectangle As New Rectangle(x2.Location.X + 20, x2.Location.Y, x2.Width - 20, x2.Height)
            If i = SelectedIndex Then
                G.FillRectangle(New SolidBrush(C1), New Rectangle(x2.Location, New Size(9, x2.Height)))


                If ImageList IsNot Nothing Then
                    Try
                        If ImageList.Images(TabPages(i).ImageIndex) IsNot Nothing Then
                            G.DrawImage(ImageList.Images(TabPages(i).ImageIndex), New Point(textrectangle.Location.X + 8, textrectangle.Location.Y + 6))
                            G.DrawString("      " & TabPages(i).Text, Font, Brushes.Black, textrectangle, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
                        Else
                            G.DrawString(TabPages(i).Text, Font, Brushes.Black, textrectangle, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
                        End If
                    Catch ex As Exception
                        G.DrawString(TabPages(i).Text, Font, Brushes.Black, textrectangle, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
                    End Try
                Else
                    G.DrawString(TabPages(i).Text, Font, Brushes.Black, textrectangle, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
                End If

            Else
                If ImageList IsNot Nothing Then
                    Try
                        If ImageList.Images(TabPages(i).ImageIndex) IsNot Nothing Then
                            G.DrawImage(ImageList.Images(TabPages(i).ImageIndex), New Point(textrectangle.Location.X + 8, textrectangle.Location.Y + 6))
                            G.DrawString("      " & TabPages(i).Text, Font, Brushes.DimGray, textrectangle, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
                        Else
                            G.DrawString(TabPages(i).Text, Font, Brushes.DimGray, textrectangle, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
                        End If
                    Catch ex As Exception
                        G.DrawString(TabPages(i).Text, Font, Brushes.DimGray, textrectangle, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
                    End Try
                Else
                    G.DrawString(TabPages(i).Text, Font, Brushes.DimGray, textrectangle, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
                End If
            End If
        Next

        e.Graphics.DrawImage(B.Clone, 0, 0)
        G.Dispose() : B.Dispose()
    End Sub
End Class