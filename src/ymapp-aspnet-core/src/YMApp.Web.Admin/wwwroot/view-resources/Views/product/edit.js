layui.use(['form', 'layedit', 'laydate'], function(){
  var form = layui.form
  ,layer = layui.layer
  ,layedit = layui.layedit
  ,laydate = layui.laydate;


    form.on('submit(demo2)', function(data){
        //layer.alert(JSON.stringify(data.field), {
        //title: '最终的提交信息'
        // })

        var list=$(".product-field-list");
    for(var i=0;i<list.length;i++)
    {
        var item=list[i];
        var categoryId=$(item).find("legend").attr("_fieldCategoryId");
        var name=$(item).find("legend").attr("_fieldName");
        alert(name);
    }

        return false;
    });



});