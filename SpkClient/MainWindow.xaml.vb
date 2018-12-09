Imports MahApps.Metro.Controls
Imports System.IO

Class MainWindow
    Inherits MetroWindow

    Private Sub EncryptButton_Click(sender As Object, e As RoutedEventArgs) Handles EncryptButton.Click
        Dim assembly = Reflection.Assembly.LoadFile(Path.GetFullPath("SpkCOM.dll"))
        Dim comType As Type = Type.GetTypeFromProgID("SpkCOM.SpkCryptoService")
        Dim cryptoService = Activator.CreateInstance(comType)
        EncryptedInput.Text = cryptoService.Encrypt(SourceInput.Text, EncryptKey.Text)
    End Sub

    Private Sub DecryptButton_Click(sender As Object, e As RoutedEventArgs) Handles DecryptButton.Click
        Dim assembly = Reflection.Assembly.LoadFile(Path.GetFullPath("SpkCOM.dll"))
        Dim comType As Type = Type.GetTypeFromProgID("SpkCOM.SpkCryptoService")
        Dim cryptoService = Activator.CreateInstance(comType)
        DecryptedOutput.Text = cryptoService.Decrypt(EncryptedInput.Text, DecryptKey.Text)
    End Sub

End Class
