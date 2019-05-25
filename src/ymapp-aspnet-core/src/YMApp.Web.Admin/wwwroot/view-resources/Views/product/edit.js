layui.use(['form', 'jquery', 'layedit', 'upload', 'laydate'], function () {
    var form = layui.form
        , $ = layui.jquery
        , layer = layui.layer
        , layedit = layui.layedit
        , laydate = layui.laydate
        , upload = layui.upload;

    var _productService = abp.services.app.product;

    //普通图片上传
    var uploadInst = upload.render({
        elem: '#pictureUpload'
        , url: '/pictures/post/'
        , before: function (obj) {
            //预读本地文件示例，不支持ie8
            obj.preview(function (index, file, result) {
                $('#demo1').attr('src', result); //图片链接（base64）
                $('#demo1').attr('width', 100);
                $('#demo1').attr('height', 100);
            });
        }
        , done: function (res) {
            //如果上传失败
            if (!res.result || !res.result.isSuccess) {
                return layer.msg(res.result.msg);
            }
            //上传成功
            $("#Picture").val(res.result.data[0]);
            $("#demoText").remove();
        }
        , error: function () {
            //演示失败状态，并实现重传
            var demoText = $('#demoText');
            $("#Picture").val("");
            demoText.html('<span style="color: #FF5722;">上传失败</span> <a class="layui-btn layui-btn-xs demo-reload">重试</a>');
            demoText.find('.demo-reload').on('click', function () {
                uploadInst.upload();
            });
        }
    });

    form.on('submit(demo2)', function (data) {
        //layer.alert(JSON.stringify(data.field), {
        //title: '最终的提交信息'
        // })
        var fields = Array();
        var list = $(".product-field-list");
        for (var i = 0; i < list.length; i++) {
            var item = list[i];
            var parentField = $(item).find("fieldset").find("legend");
            var fieldId = $(parentField).attr("_fieldid");
            var fieldName = $(parentField).attr("_fieldname");
            var parentId = $(parentField).attr("_pid");
            var model = { FieldId: fieldId, FieldName: fieldName, ParentId: parentId, FieldValue: "" };
            fields.push(model);

            var childFields = $(item).find(".layui-form-item");
            for (var j = 0; j < childFields.length; j++) {
                var citem = childFields[j];
                var cmodel = { FieldId: $(citem).attr("_fieldid"), FieldName: $(citem).attr("_fieldname"), ParentId: $(citem).attr("_pid"), FieldValue: $(citem).find("input").val() };
                fields.push(cmodel);
            }
        }
        var pictures = Array();
        var picture = { Url: $("#Picture").val(), LinkUrl: "", Type: 1, Name: "", Sort: 0 };
        pictures.push(picture);
        var requestModel = { product: data.field, pictures: pictures, productAttributes: fields };
        console.log(requestModel);

        _productService.createOrUpdate(requestModel).done(function () {
            //_$modal.modal('hide');
            // 获得frame索引
            var index = parent.layer.getFrameIndex(window.name);
            //关闭当前frame
            parent.layer.close(index);
            parent.location.reload(true); //reload page to see edited user!
        }).always(function () {
            //abp.ui.clearBusy(_$modal);
        });
        return false;
    });

    var ue = UE.getEditor('Describe', {
        initialFrameHeight: 320
    });


});