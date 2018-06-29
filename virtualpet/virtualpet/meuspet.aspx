<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="meuspet.aspx.cs" Inherits="virtualpet.meuspet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Meus Pets</title>
    <link rel="stylesheet" type="text/css" media="screen" href="StyleSheet.css" />
    <link href="https://fonts.googleapis.com/css?family=VT323" rel="stylesheet"/>
    <style>  
        .panel {
            margin: 30px;
        }

        .panel-body {
            background: grey;
            border: 2px solid black;
        }

        .panel-title {
            background: black;
            color: white;
            widht: 100%;
            margin: 0;
            padding: 5px;
        }
        #input-newpet {
            height: 40px;
            width: 100%;
            border-left: 2px solid black;
            border-right: 2px solid black;
            box-sizing: border-box;
            padding
        }

        #input-newpet #nomedoPet {
            height: 100%;
            box-sizing: border-box;
            width: 70%;
            margin: 0;
            font-size: x-large;
            font-family: "VT323";
            padding-left: 5px;
        }

        #input-newpet #novopet {
            height: 100%;
            margin:0;
            width: 30%;
            border: none;
            background: white;
            font-family: VT323;
            font-size: 1.25rem;
            float: right;
            border-left: 2px solid;
        }

        #input-newpet #novopet:hover {
            cursor: pointer;
        }

        .list-item {
            border-bottom: 2px solid black;
            padding: 10px;
        }

        .list-item .list-right {
            float: right;
        }

        .list-item .list-left {
            display: inline-block;
        }


    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="nav">
            <a class="brand">VPET</a>
            <a class="item" href="/meuspet.aspx">MEUS PETS</a>
            <a class="item" href="/ranking.aspx">RANKING</a>
        </div>

        <div class="container">
            <div class="panel">
                <h2 class="panel-title">Meus Pets</h2>
                <div id="input-newpet">
                    <asp:TextBox runat="server" ID="nomedoPet" Text="" />
                    <asp:Button Text="NOVO PET" runat="server" OnClick="criarPet" id="novopet"/>
                </div>
                <div class="panel-body">
                    <% var pets = meusPets(); %>
                    <% if (pets != null)
                        { %>
                        <% foreach (virtualpet.Models.Pet pet in pets)
                            {%>
                                <div class="list-item">
                                    <div class="list-left">
                                        <p class="title"><a href="principal.aspx?petnome=<%= pet.nomePet %>"><%= pet.nomePet %></p></a>
                                    </div>
                                    <div class="list-right">
                                        <p class="title">Pts: <%= pet.pontos%></p>
                                    </div>
                                </div>
                        <% } %>
                    <% } %>

                    <% else
                        { %>
                    <h5>Você não possui Pet</h5>
                    <%} %>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
