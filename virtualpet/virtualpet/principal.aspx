<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="principal.aspx.cs" Inherits="virtualpet.principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
    <link href="https://fonts.googleapis.com/css?family=VT323" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>VPet</title>
    <style>
        .panel {
            background: grey;
            padding: 10px;
            width: 100%;
            border: 2px solid black;
            border-radius: 5%;
            margin-top: 20px;
        }

        .btn-line {
            display: table;
            border-radius: 0;
        }

        .btn {
            margin: 0;
        }

        .panel p{
            text-align: center;
        }

        footer {
            position: absolute;
            bottom: 0;
        }

    </style>

    <meta http-equiv="refresh" content="1">
</head>

<body>
    <form id="form1" runat="server">

        <div id="overlay"></div>
        <div id="background"></div>

        <div class="nav" style="">
            <a class="brand">VPET</a>
            <a class="item" href="/meuspet.aspx">MEUS PETS</a>
            <a class="item" href="/ranking.aspx">RANKING</a>
            <div class="minigame" style="visibility: hidden; display: inline">
                Pontos:
                <span style="font-size: 1.7rem" id="pts" runat="server">0</span>
                <asp:Button Text="Sair" runat="server" CssClass="btn" OnClick="Sair" />
            </div>
        </div>
        <asp:Button Text="Excluir" runat="server" OnClick="excluir_Click" />
        <asp:Button Text="Reiniciar" runat="server" OnClick="reinicar_Click" />
        <div id="balloons" style="visibility: hidden;"></div>

        <div class="container">

            <div class="panel">

                <div class="btn-line">
                    <asp:Button Text="Feed" runat="server" CssClass="btn" class="btn" OnClick="Feed" />
                    <asp:Button Text="flush" runat="server" CssClass="btn" class="btn" />
                    <asp:Button Text="cure" runat="server" CssClass="btn" class="btn" OnClick="Cure" />
                    <asp:Button Text="lights" runat="server" CssClass="btn" OnClick="Unnamed_Click" />
                    <button class="btn" id="play" type="button">Play</button>
                </div>

            <p>
                <asp:Label ID="labelnome" runat="server"></asp:Label></p>

            <div id="screen">
                <div class="pixelart-to-css"></div>
            </div>

            <p id="estado">
                Estado:
                <span>
                    <asp:Label ID="labelestado" runat="server"></asp:Label></span>
            </p>

            <div class="status">
                <span>Health</span>
                <div class="bar">
                    <div runat="server" class="progress" id="health"></div>
                </div>
            </div>

            <div class="status">
                <span>Hungry</span>
                <div class="bar">
                    <div runat="server" class="progress" style="background-color: orange" id="hungry"></div>
                </div>
            </div>

            <div class="status">
                <span>Happy</span>
                <div class="bar">
                    <div runat="server" class="progress" style="background-color: red" id="happy"></div>
                </div>
            </div>
        </div>
    </div>

    <footer>
        <p class="text-center">&copy 2018 Universidade Tecnológica Federal do Paraná</p>
    </footer>
     </form>
    <script src="https://code.jquery.com/jquery-3.3.1.min.js" integrity="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8="
        crossorigin="anonymous"></script>
        <script src="vpet.js" language="javascript" type="text/javascript"></script>
</body>

</html>
