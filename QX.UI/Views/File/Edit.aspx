﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BasePage.Master" Inherits="System.Web.Mvc.ViewPage<QX.Model.Bse_File>" %>

<%@ Import Namespace="QX.HtmlHelperLib" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Add
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="FileInfo" method='post' action="/File/FileOperation">
    <fieldset class="DocmentsWidth">
        <legend>文件维护</legend>
        <input type="hidden" id="formOper" value="edit" name="formOper" />
        <input type="hidden" id="optype" value="nor" name="optype" />
        <%=Html.AutoBindForm<QX.Model.Bse_File>("Bse_FileModule", "Bse_File",Model,false,false,false)%>
    </form>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">正文</a></li>
            <li><a href="#tabs-2">附件</a></li>
            <li><a href="#tabs-3">分发</a></li>
        </ul>
        <div id="tabs-1">
            
            <%Html.RenderPartial("FCKEditor", string.IsNullOrEmpty(Model.CF_Bak) ? "" : Model.CF_Bak); %>
        </div>
        <div id="tabs-2">
            <%Html.RenderPartial("AttachmentsControl", "uploadCallback", new ViewDataDictionary { new KeyValuePair<string, object>("UploadUrl", "/Doc/Upload/"), new KeyValuePair<string, object>("FileType", "File") }); %>
            <%=Html.GenToolbarHelper("Doc_AttachmentModule", "Doc_Attachment", "delN:'删除附件',delFunJs:'Del()'")%>
            <%=Html.SysComm_JqGrid("Doc_AttachmentModule", "Doc_Attachment", "/Doc/GetAttachmentList/"+Model.CF_Code+"-Bse_FileModule", true)%>
        </div>
        <div id="tabs-3">
            <%=Html.GenToolbarHelper("Doc_AllotModule", "Doc_Allot", "addN:'分发',addFunJs:'Allot()',delN:'删除',delFunJs:'Del()'")%>
            
            <%=Html.SysComm_JqGrid("Doc_AllotModule", "Doc_Allot", "/Doc/GetAllot/"+Model.CF_Code, true)%>
        </div>
    </div>
    <div class="FormToolBar">
        <input type='button' name='button' value='草稿' onclick='File_Operation.SaveDraft()' />
        <input type='button' name='button' value='提交' onclick='File_Operation.SaveData()' />
        <input type='button' name='cancle' value='返回' onclick='ComOperation.CancelEdit()' />
    </div>
    <%=Html.AutoBindValidate("Bse_FileModule", "FileInfo")%>
    </fieldset>
<%=Html.ReferControlEx("Bse_GroupRefModule", "Bse_Group", false)%>
    <script type="text/javascript">

        function GetbackUrl() {
            var backUrl = '<%=ViewData["backUrl"]%>';
            return backUrl;
        }

        function Doc_AllotAllot() {

        }



        function Doc_AttachmentDel() {
            var grid = $('#Doc_Attachmentgrid');
            var curid = grid.getGridParam('selrow'); //获取选择行的id
            var data = grid.getRowData(curid);
            if (data.Dat_Code == undefined) {
                ShowMsg("请选中要操作的数据!");
                return;
            }

            ShowMsg('你确定要删除选中的数据吗?', function(yes) {
                if (yes) {
                    $.ajax({
                        type: 'post',
                        url: '/Doc/AttachmentDelete/',
                        data: { id: data.Dat_Code, oper: 'del' },
                        success: function(result) {
                            if (result.result == 'success') {
                                $('#Doc_Attachmentgrid').trigger('reloadGrid');
                            } else {
                                ShowMsg('删除失败');
                            }
                        }
                    });
                }
            });
        }


        function Doc_AllotDel() {
            var grid = $('#Doc_Allotgrid');
            var curid = grid.getGridParam('selrow'); //获取选择行的id
            var data = grid.getRowData(curid);
            if (data.DA_Code == undefined) {
                ShowMsg("请选中要操作的数据!");
                return;
            }

            ShowMsg('你确定要删除选中的数据吗?', function(yes) {
                if (yes) {
                    $.ajax({
                        type: 'post',
                        url: '/Doc/AllotDelete/',
                        data: { id: data.DA_Code, oper: 'del' },
                        success: function(result) {
                            if (result.result == 'success') {
                                $('#Doc_Allotgrid').trigger('reloadGrid');
                            } else {
                                ShowMsg('删除失败');
                            }
                        }
                    });
                }
            });

        }

        function uploadCallback(id, fpath) {
         
            $.ajax({
                type: "post",
                url: "/File/UploadFile",
                dataType: "json",
                data: { code: $("#CF_Code").val(), path: fpath, module: "Bse_FileModule" },
                success: function(re, textStatus) {
                    //                $("#Doc_Attachmentgrid").trigger("reloadGrid");
                    $("#Doc_Attachmentgrid").setGridParam({ url: '/Doc/GetAttachmentList/' + $("#CF_Code").val() + '-Bse_FileModule' }).trigger("reloadGrid");
                }
            });

        }

        $(document).ready(function() {


            //            $("#example").multiselect({
            //                checkAllText: "全选",
            //                unCheckAllText: "不选",
            //                selectedList: 100 // 0-based index
            //            });

        //群组人员授权
        $("#Doc_Allot_add").click(function() {
            Bse_GroupRefModuleBse_GroupOpenRefer(function(data) {
                $.ajax({
                    type: "post",
                    url: "/Doc/GroupAllot",
                    dataType: "json",
                    data: { code: $("#CF_Code").val(), group: data.GP_Code, module: "Bse_GroupModule" },
                    success: function(re, textStatus) {
                        //                $("#Doc_Attachmentgrid").trigger("reloadGrid");
                        $("#Doc_Allotgrid").trigger("reloadGrid");
                    }
                });
            });
        });

//            Common_EmpTree_DialogDept.Init("Doc_Allot_add", function(code, name) {
//                //                for (var p in array) {
//                //                    alert(array[p][0]);
//                //                }
//                //人员回写
//                $.ajax({
//                    type: "post",
//                    url: "/Doc/DocAllot",
//                    dataType: "json",
//                    data: { code: code.join(','), name: name.join(','), doc: $("#Doc_Code").val(), module: 'Bse_FileModule' },
//                    success: function(re, textStatus) {
//                        //                $("#Doc_Attachmentgrid").trigger("reloadGrid");
//                        $("#Doc_Allotgrid").trigger("reloadGrid");
//                    }
//                });
//            });
            File_Operation.Init();
            $("#tabs").tabs();

            //$("#Doc_Allotgrid").setGridParam({ url: '/Doc/GetAllot/' + $("#Doc_Code").val() }).trigger("reloadGrid");

            // Doc_Allot_Doc_AllotModule_GridControl.Init('/Doc/GetAllot/'+$("#Doc_Code").val(),"Doc_Allot");
        });
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderExtend" runat="server">
    <link href="/Content/css/jquery.multiselect.css" rel="stylesheet" type="text/css" />

    <script src="/Scripts/Shared/jquery.multiselect.min.js" type="text/javascript"></script>

    <script src="/Scripts/Shared/Dict.js" type="text/javascript"></script>

    <script src="/Scripts/Shared/Dept.js" type="text/javascript"></script>

</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="TopMenu" runat="server">
</asp:Content>
