<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.pnlPlayArea = New System.Windows.Forms.Panel()
        Me.imlImg = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'pnlPlayArea
        '
        Me.pnlPlayArea.Location = New System.Drawing.Point(132, 28)
        Me.pnlPlayArea.Name = "pnlPlayArea"
        Me.pnlPlayArea.Size = New System.Drawing.Size(318, 404)
        Me.pnlPlayArea.TabIndex = 0
        '
        'imlImg
        '
        Me.imlImg.ImageStream = CType(resources.GetObject("imlImg.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlImg.TransparentColor = System.Drawing.Color.Transparent
        Me.imlImg.Images.SetKeyName(0, "empty.png")
        Me.imlImg.Images.SetKeyName(1, "head.png")
        Me.imlImg.Images.SetKeyName(2, "body.png")
        Me.imlImg.Images.SetKeyName(3, "snail.png")
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(643, 459)
        Me.Controls.Add(Me.pnlPlayArea)
        Me.KeyPreview = True
        Me.Name = "frmMain"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlPlayArea As System.Windows.Forms.Panel
    Friend WithEvents imlImg As System.Windows.Forms.ImageList

End Class
