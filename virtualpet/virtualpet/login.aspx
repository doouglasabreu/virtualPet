<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="virtualpet.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link href="StyleSheet.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=VT323" rel="stylesheet" />
    <style>
        .btn {
            margin: 10px 0;
        }

        .panel {
            background: grey;
            border: 2px solid black;
            margin: 30px;
        }

        .panel-body {
            padding: 10px;
        }

        .panel-title {
            background: black;
            color: white;
            widht: 100%;
            height: 30px;
            margin: 0;
            padding: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="panel">
                <h2 class="panel-title">Login</h2>
                <div class="panel-body">
                    <p>Nome:</p>
                    <asp:TextBox runat="server" ID="nome" Width="100%" BorderWidth="2px" Height="20px" Font-Names="VT323" Font-Size="X-Large" />
                    <p>Senha:</p>
                    <asp:TextBox runat="server" ID="senha" TextMode="Password" Width="100%" BorderWidth="2px" Height="20px" Font-Names="VT323" Font-Size="X-Large" />
                    <asp:Button class="btn" Text="Entrar" runat="server" OnClick="Btn_Entrar" />
                    <asp:Button class="btn" Text="Cadastrar" runat="server" OnClick="Btn_Cadastrar" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
