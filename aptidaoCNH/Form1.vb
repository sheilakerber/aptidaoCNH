Public Class Form1
    ' configurando o formato da data para dia-mes-ano
    Private Sub datePicker_ValueChanged(sender As Object, e As EventArgs) Handles datePicker.ValueChanged
        datePicker.Format = DateTimePickerFormat.Custom
        datePicker.CustomFormat = "dd-MM-yyyy"
    End Sub

    ' ao clicar no botao 'Verificar'
    Private Sub btnVerificar_Click(sender As Object, e As EventArgs) Handles btnVerificar.Click
        ' declaracao de variaveis
        Dim nascimento, dataAtual As Date
        Dim idade As Integer
        Dim nome As String

        ' validacao do input nome
        If (txtNome.Text = Nothing Or IsNumeric(txtNome.Text)) Then
            MsgBox("O campo nome não está preenchido ou não é válido!", MsgBoxStyle.Critical, "Atenção!")
            Exit Sub
        End If

        nome = txtNome.Text
        nascimento = datePicker.Value
        dataAtual = Now     'data atual do sistema

        ' calculo da idade (/365.25 para considerar anos bissextos)
        idade = DateDiff(DateInterval.Day, nascimento, dataAtual) / 365.25

        ' lógica para exibir o resultado
        If (idade >= 18) Then
            MsgBox(txtNome.Text & " tem " & Format(idade, "##") & " anos e, portanto, ESTÁ apto(a) para fazer a habilitação.", MsgBoxStyle.Information, "Resultado:")
        Else
            MsgBox(txtNome.Text & " tem " & Format(idade, "##") & " ano(s) e, portanto, NÃO ESTÁ apto(a) para fazer a habilitação.", MsgBoxStyle.Information, "Resultado:")
        End If
    End Sub
End Class
