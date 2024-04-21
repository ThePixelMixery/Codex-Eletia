extends Node

var inv: Dictionary = {
    "tools": []
}

func _ready():
    pass

func add_tool(tool_name: String, type: String, grade: String, uses: int):
    var new_tool = {
        "name": tool_name,
        "type": type,
        "grade": grade,
        "uses": uses
    }
    var logmessage: String
    inv.inv["tools"].append(new_tool)
    emit.tool_added.emit(new_tool)
    logmessage = "%s %s %s added to inventory. It has %d uses" % [grade, type, tool_name, uses]
    log.add_event(logmessage, "tools")

func use_tool(tool_id:int):
    var tool_info = inv.inv["tools"][tool_id]
    var logmessage: String
    inv.inv["tools"][tool_id]["uses"] -= 1    
    #removes tool if uses reach zero
    if inv.inv["tools"][tool_id] <= 0:
        logmessage = "%s %s %s broke" % [tool_info["grade"], tool_info["type"], tool_info["tool_name"]]
        emit.tool_removed.emit(inv.inv["tools"][tool_id])
        log.add_event(logmessage, "tools")
        inv.inv["tools"].pop_at(tool_id)
    else:
        logmessage = "%s %s %s has %d left" % [tool_info["grade"], tool_info["type"], tool_info["tool_name"], tool_info["uses"]]
        log.add_event(logmessage, "tools")
        
