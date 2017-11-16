<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Documentation
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Name")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("<to be defined>")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Full Name", New System.Windows.Forms.TreeNode() {TreeNode2})
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("<to be defined>")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Version", New System.Windows.Forms.TreeNode() {TreeNode4})
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("<to be defined>")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Dev State", New System.Windows.Forms.TreeNode() {TreeNode6})
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("<to be defined>")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Framework target", New System.Windows.Forms.TreeNode() {TreeNode8})
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("<to be defined>")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Copyright", New System.Windows.Forms.TreeNode() {TreeNode10})
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("<to be defined>")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Credits", New System.Windows.Forms.TreeNode() {TreeNode12})
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("<to be defined>")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("License", New System.Windows.Forms.TreeNode() {TreeNode14})
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Visible Source")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Code", New System.Windows.Forms.TreeNode() {TreeNode16})
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("https://github.com/SmokeyTheBandicoot/GameShardsCore")
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Repository", New System.Windows.Forms.TreeNode() {TreeNode18})
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Overview", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode3, TreeNode5, TreeNode7, TreeNode9, TreeNode11, TreeNode13, TreeNode15, TreeNode17, TreeNode19})
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Detailed documentation included")
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Visible souce code")
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Maintained and evolving")
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Open to suggestions")
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Features", New System.Windows.Forms.TreeNode() {TreeNode21, TreeNode22, TreeNode23, TreeNode24})
        Dim TreeNode26 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Not completed")
        Dim TreeNode27 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Not implemented")
        Dim TreeNode28 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Not Documented")
        Dim TreeNode29 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Account Manager", New System.Windows.Forms.TreeNode() {TreeNode26, TreeNode27, TreeNode28})
        Dim TreeNode30 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Advanced Math")
        Dim TreeNode31 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("How to use")
        Dim TreeNode32 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Group syntax")
        Dim TreeNode33 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Function syntax")
        Dim TreeNode34 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Logic operators")
        Dim TreeNode35 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Syntax", New System.Windows.Forms.TreeNode() {TreeNode32, TreeNode33, TreeNode34})
        Dim TreeNode36 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Regular Expression", New System.Windows.Forms.TreeNode() {TreeNode31, TreeNode35})
        Dim TreeNode37 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Documentation", New System.Windows.Forms.TreeNode() {TreeNode29, TreeNode30, TreeNode36})
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.t = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(12, 12)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "Nodo3"
        TreeNode1.Text = "Name"
        TreeNode2.Name = "Nodo6"
        TreeNode2.Text = "<to be defined>"
        TreeNode3.Name = "Nodo5"
        TreeNode3.Text = "Full Name"
        TreeNode4.Name = "Nodo8"
        TreeNode4.Text = "<to be defined>"
        TreeNode5.Name = "Nodo7"
        TreeNode5.Text = "Version"
        TreeNode6.Name = "Nodo10"
        TreeNode6.Text = "<to be defined>"
        TreeNode7.Name = "Nodo9"
        TreeNode7.Text = "Dev State"
        TreeNode8.Name = "Nodo12"
        TreeNode8.Text = "<to be defined>"
        TreeNode9.Name = "Nodo11"
        TreeNode9.Text = "Framework target"
        TreeNode10.Name = "Nodo15"
        TreeNode10.Text = "<to be defined>"
        TreeNode11.Name = "Nodo14"
        TreeNode11.Text = "Copyright"
        TreeNode12.Name = "Nodo18"
        TreeNode12.Text = "<to be defined>"
        TreeNode13.Name = "Nodo17"
        TreeNode13.Text = "Credits"
        TreeNode14.Name = "Nodo20"
        TreeNode14.Text = "<to be defined>"
        TreeNode15.Name = "Nodo19"
        TreeNode15.Text = "License"
        TreeNode16.Name = "Nodo22"
        TreeNode16.Text = "Visible Source"
        TreeNode17.Name = "Nodo21"
        TreeNode17.Text = "Code"
        TreeNode18.Name = "Nodo24"
        TreeNode18.Text = "https://github.com/SmokeyTheBandicoot/GameShardsCore"
        TreeNode19.Name = "Nodo23"
        TreeNode19.Text = "Repository"
        TreeNode20.Name = "Nodo0"
        TreeNode20.Text = "Overview"
        TreeNode21.Name = "Nodo13"
        TreeNode21.Text = "Detailed documentation included"
        TreeNode22.Name = "Nodo25"
        TreeNode22.Text = "Visible souce code"
        TreeNode23.Name = "Nodo26"
        TreeNode23.Text = "Maintained and evolving"
        TreeNode24.Name = "Nodo27"
        TreeNode24.Text = "Open to suggestions"
        TreeNode25.Name = "Nodo1"
        TreeNode25.Text = "Features"
        TreeNode26.Name = "Nodo29"
        TreeNode26.Text = "Not completed"
        TreeNode27.Name = "Nodo30"
        TreeNode27.Text = "Not implemented"
        TreeNode28.Name = "Nodo31"
        TreeNode28.Text = "Not Documented"
        TreeNode29.Name = "Nodo28"
        TreeNode29.Text = "Account Manager"
        TreeNode30.Name = "Nodo32"
        TreeNode30.Text = "Advanced Math"
        TreeNode31.Name = "Nodo34"
        TreeNode31.Text = "How to use"
        TreeNode32.Name = "Nodo36"
        TreeNode32.Text = "Group syntax"
        TreeNode33.Name = "Nodo37"
        TreeNode33.Text = "Function syntax"
        TreeNode34.Name = "Nodo39"
        TreeNode34.Text = "Logic operators"
        TreeNode35.Name = "Nodo35"
        TreeNode35.Text = "Syntax"
        TreeNode36.Name = "Nodo33"
        TreeNode36.Text = "Regular Expression"
        TreeNode37.Name = "Nodo2"
        TreeNode37.Text = "Documentation"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode20, TreeNode25, TreeNode37})
        Me.TreeView1.Size = New System.Drawing.Size(311, 380)
        Me.TreeView1.TabIndex = 0
        '
        't
        '
        Me.t.Location = New System.Drawing.Point(329, 12)
        Me.t.Multiline = True
        Me.t.Name = "t"
        Me.t.ReadOnly = True
        Me.t.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.t.Size = New System.Drawing.Size(452, 380)
        Me.t.TabIndex = 1
        '
        'Documentation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 404)
        Me.Controls.Add(Me.t)
        Me.Controls.Add(Me.TreeView1)
        Me.Name = "Documentation"
        Me.Text = "Documentation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TreeView1 As Windows.Forms.TreeView
    Friend WithEvents t As Windows.Forms.TextBox
End Class
