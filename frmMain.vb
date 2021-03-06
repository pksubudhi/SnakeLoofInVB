Public Class frmMain
    'Global Declaration
    Dim MaxRow As Integer = 15
    Dim MaxCol As Integer = 15
    Dim BlockSize As Integer = 20

    Dim symBlock(MaxCol * MaxRow) As PictureBox
    Dim SnakeBody(MaxCol * MaxRow) As Integer
    Dim SnakeBodySize As Integer = 0
    Dim SnailPositionIndex As Integer = -1

    Enum Symbols
        EMPTY
        HEAD
        BODY
        SNAIL
    End Enum
    Enum Direction
        EAST
        NORTH
        WEST
        SOUTH
    End Enum

    Dim SnakeDirection As Integer = Direction.EAST

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnlPlayArea.Width = BlockSize * (MaxCol + 1)
        pnlPlayArea.Height = BlockSize * (MaxRow + 1)
        FillPatters()
        InitSnake()

    End Sub
    Private Sub InitSnake()

        For I As Integer = 0 To (MaxCol * MaxRow) - 1
            SnakeBody(I) = 0
        Next
        PlotSnakeBody(7, 7, Symbols.HEAD)
        PlotSnakeBody(7, 6, Symbols.BODY)
        PlotSnakeBody(7, 5, Symbols.BODY)
        PlotSnakeBody(7, 4, Symbols.BODY)
        UpdateSnail()
    End Sub


    Private Sub FillPatters()
        Dim indexVal As Integer = 0
        Dim rPos As Integer = 0
        Dim cPos As Integer = 0

        Dim I As Integer
        Dim J As Integer
        For I = 0 To MaxRow - 1
            For J = 0 To MaxCol - 1
                symBlock(indexVal) = New PictureBox
                symBlock(indexVal).Left = cPos
                symBlock(indexVal).Top = rPos
                symBlock(indexVal).Width = BlockSize
                symBlock(indexVal).Height = BlockSize

                symBlock(indexVal).Image = imlImg.Images(0)
                symBlock(indexVal).Tag = indexVal

                pnlPlayArea.Controls.Add(symBlock(indexVal))
                cPos = cPos + BlockSize
                indexVal = indexVal + 1

            Next
            cPos = 0
            rPos = rPos + BlockSize
        Next
    End Sub
    Private Sub PlotSnakeBody(ByVal x As Integer, ByVal y As Integer, ByVal bodyPart As Integer)
        Dim arIndex As Integer
        arIndex = (x * MaxCol) + y
        symBlock(arIndex).Image = imlImg.Images(bodyPart)
        SnakeBody(SnakeBodySize) = (x * MaxCol) + y
        SnakeBodySize = SnakeBodySize + 1
    End Sub

    Private Sub frmMain_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                If SnakeDirection = Direction.SOUTH Then
                    MsgBox("Invalid Move")
                Else
                    SnakeDirection = Direction.NORTH
                End If

            Case Keys.Down
                If SnakeDirection = Direction.NORTH Then
                    MsgBox("Invalid Move")
                Else
                    SnakeDirection = Direction.SOUTH
                End If
            Case Keys.Right
                If SnakeDirection = Direction.WEST Then
                    MsgBox("Invalid Move")
                Else
                    SnakeDirection = Direction.EAST
                End If
            Case Keys.Left
                If SnakeDirection = Direction.EAST Then
                    MsgBox("Invalid Move")
                Else
                    SnakeDirection = Direction.WEST
                End If
            Case Else
                MsgBox("Invalid")

        End Select
        UpdateSnake()
    End Sub
    Private Sub UpdateSnake()
        Dim rVal As Integer
        Dim cVal As Integer
        Dim NewHeadPos As Integer = 0
        cVal = SnakeBody(0) Mod MaxCol
        rVal = SnakeBody(0) \ MaxCol


        Select Case SnakeDirection
            Case Direction.EAST
                cVal = cVal + 1
            Case Direction.NORTH
                rVal = rVal - 1
            Case Direction.WEST
                cVal = cVal - 1
            Case Direction.SOUTH
                rVal = rVal + 1
        End Select
        If rVal < 0 Or rVal > (MaxRow - 1) Or cVal < 0 Or cVal > (MaxCol - 1) Then
            Me.KeyPreview = False
            MsgBox("Game End")
            Exit Sub
        End If
        NewHeadPos = (rVal * MaxCol) + cVal
        If NewHeadPos = SnailPositionIndex Then
            SnakeBodySize = SnakeBodySize + 1

        Else
            symBlock(SnakeBody(SnakeBodySize - 1)).Image = imlImg.Images(Symbols.EMPTY)
        End If

        For i As Integer = SnakeBodySize - 1 To 1 Step -1
            SnakeBody(i) = SnakeBody(i - 1)
        Next

        SnakeBody(0) = (rVal * MaxCol) + cVal
        If NewHeadPos = SnailPositionIndex Then
            UpdateSnail()
        End If
        symBlock(NewHeadPos).Image = imlImg.Images(Symbols.HEAD)
        ReDrawSnake()
    End Sub
    Private Sub ReDrawSnake()
        symBlock(SnakeBody(0)).Image = imlImg.Images(Symbols.HEAD)
        For i As Integer = 1 To SnakeBodySize - 1
            symBlock(SnakeBody(i)).Image = imlImg.Images(Symbols.BODY)
        Next
    End Sub
    Private Sub UpdateSnail()
        Dim Num As Integer = -1
        Randomize()
        Dim rnd As Random = New Random()
        Num = rnd.Next() Mod (MaxCol * MaxRow)

        While IsBodyPart(Num)

            Num = rnd.Next() Mod (MaxCol * MaxRow)
        End While
        SnailPositionIndex = Num
        symBlock(SnailPositionIndex).Image = imlImg.Images(Symbols.SNAIL)
    End Sub
    Private Function IsBodyPart(ByVal x As Integer) As Boolean
        For I As Integer = 0 To SnakeBodySize - 1
            If x = SnakeBody(I) Then
                Return True
            End If
        Next
        Return False
    End Function
End Class
