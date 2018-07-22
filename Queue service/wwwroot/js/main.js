var xml;
$(function () {
  $('button').click(function () {
    xml="<?xml version='1.0' encoding='utf-8'?><!DOCTYPE recipe> <type>" + $('#whereToGo').val() + " </type><description> " + $('#description').val() + " </description><isdone> " + $('#checkbox').is(':checked') + "</isdone></type>";

    //xml=($('#whereToGo').val() + " " + $('#description').val() + "  " + $('#checker').val() + " ");
    console.log(xml);



  });


});
//<?xml version="1.0" encoding="utf-8"?>
//<!DOCTYPE recipe>
//xml=("<type>" + $('#whereToGo').val() " </type><description> " + $('#description').val() + " </description><isdone> " + $('#checker').val() + "</isdone></type>");
