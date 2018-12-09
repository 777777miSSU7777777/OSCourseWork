Imports MahApps.Metro.Controls
Imports System.IO

Class MainWindow
    Inherits MetroWindow

    Private cryptoService

    Public Sub New()
        Reflection.Assembly.LoadFile(Path.GetFullPath("SpkCOM.dll"))
        Dim comType As Type = Type.GetTypeFromProgID("SpkCOM.SpkCryptoService")
        cryptoService = Activator.CreateInstance(comType)
    End Sub

    Private Sub EncryptButton_Click(sender As Object, e As RoutedEventArgs) Handles EncryptButton.Click
        EncryptedInput.Text = cryptoService.Encrypt(SourceInput.Text, EncryptKey.Text)
    End Sub

    Private Sub DecryptButton_Click(sender As Object, e As RoutedEventArgs) Handles DecryptButton.Click
        DecryptedOutput.Text = cryptoService.Decrypt(EncryptedInput.Text, DecryptKey.Text)
    End Sub

End Class
