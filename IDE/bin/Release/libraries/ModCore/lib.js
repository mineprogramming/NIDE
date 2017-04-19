var scripts = net.zhuoweizhang.mcpelauncher.ScriptManager.scripts;
var ScriptableObject = org.mozilla.javascript.ScriptableObject;

for(var i = 0; i < scripts.size(); i++){
 script = scripts.get(i);
 scope = script.scope;
 if(script.name.split(' ')[0]=="ModCore"){ //Если первое слово в имени скрипта - ModCore
  var ModAPI = ScriptableObject.getProperty(scope, "ModAPI");
  var ToolMaterial = ScriptableObject.getProperty(scope, "ToolMaterial");
  var ToolType = ScriptableObject.getProperty(scope, "ToolType");
  var random = ScriptableObject.getProperty(scope, "random");
  var drop = ScriptableObject.getProperty(scope, "drop");
  var translate = ScriptableObject.getProperty(scope, "translate");
 }
}