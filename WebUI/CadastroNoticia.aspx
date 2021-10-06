<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroNoticia.aspx.cs" Inherits="SimuladoDAWPP.CadastroNoticia" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Cadastro de Notícia</h2>
    <p>Código: 
        <asp:TextBox ID="txbCodigo" runat="server"></asp:TextBox>
    &nbsp;<asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
    </p>
    <p>Título: 
        <asp:TextBox ID="txbTitulo" runat="server"></asp:TextBox>
    </p>
    <p>Data:
        <asp:TextBox ID="txbData" runat="server"></asp:TextBox>
    </p>
    <p>Notícia: 
        <asp:TextBox ID="txbNoticia" runat="server" Height="183px" TextMode="MultiLine" Width="276px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnInserir" runat="server" Text="Inserir" OnClick="btnInserir_Click" />&nbsp;<asp:Button ID="btnAlterar" runat="server" Text="Alterar" OnClick="btnAlterar_Click" />&nbsp;<asp:Button ID="btnExcluir" runat="server" Text="Excluir" Height="26px" OnClick="btnExcluir_Click" />
    &nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
    </p>
    <p>
        <asp:GridView ID="gvNoticias" runat="server" EmptyDataText="Não existem notícias a serem exibidas." AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="748px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="CdNoticia" HeaderText="Código Notícia">
                <HeaderStyle Font-Bold="True" Font-Italic="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Bold="False" />
                </asp:BoundField>
                <asp:BoundField DataField="DsTitulo" HeaderText="Título Notícia">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="DtNoticia" HeaderText="Data Notícia">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="DsNoticia" HeaderText="Descrição Notícia">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    </p>
</asp:Content>
