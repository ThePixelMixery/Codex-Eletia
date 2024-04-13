extends Node

var inv: Dictionary = {
    "tools": []
}


# name, grade, and charges?

signal tool_added (tool_name: String)
signal tool_removed (tool_name: String)

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
    tool_added.emit(tool_name)
    logmessage = "%s %s %s added to inventory. It has %d uses" % [grade, type, tool_name, uses]
    log.add_event(logmessage, "tools")

func use_tool(tool_id:int):
    var tool_info = inv.inv["tools"][tool_id]
    var logmessage: String
    inv.inv["tools"][tool_id]["uses"] -= 1    
    if inv.inv["tools"][tool_id] <= 0:
        logmessage = "%s %s %s broke" % [tool_info["grade"], tool_info["type"], tool_info["tool_name"]]
        log.add_event(logmessage, "tools")
        inv.inv["tools"].pop_at(tool_id)
        tool_removed.emit(tool_info["tool_name"])
    else:
        logmessage = "%s %s %s has %d left" % [tool_info["grade"], tool_info["type"], tool_info["tool_name"], tool_info["uses"]]
        log.add_event(logmessage, "tools")
        
