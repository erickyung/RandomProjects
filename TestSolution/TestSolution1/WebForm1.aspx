<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script  runat="server">
    public void BtClick1(Object obj, EventArgs e)
    {
        lblMsg.Text = "OnClick script: Hello!";
    }
    
    public void Page_Load(Object obj, EventArgs e)
    {
        Button1.Attributes.Add("onclick", string.Format("btClick2('{0}')", lblMsg.ClientID));
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Title</title>
    </head>
    <body>
        <form id="Form1" runat="server">
            <asp:Panel ID="pnlPanel" runat="server">
                <asp:Button ID="Button1" OnClick="BtClick1" Text="Click Me" runat="server" />
                <br />
                <asp:label id="lblMsg" runat="server" />
            </asp:Panel>
        </form>
        
        <script  type="text/javascript">
            function btClick2() {
                return confirm('OnClientClick script: Press OK to continue.');
            }
        </script>
    </body>
</html>
