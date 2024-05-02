extends Node

'''
story, 
loot, 
unlock, 
tools 
'''

# emit signal to log object to create new entry
func add_event(message:String, type: String, reminder:bool = false):

    #safety net for weird logs
    var allowed = false
    match type:
        "tools":
            allowed = global.settings["events"]["tools"]
        "test":
            allowed = true
        "system":
            allowed = true
    if allowed:

        #creates label to send to log object
        var entry = Label.new() 
        var message_total: String = message
        if reminder:
            message_total = "Reminder: " + message_total
        #for timestamps
        if global.settings["events"]["settings"]:
            message_total = current_time() + message_total
        entry.text = message_total
        emit.log_entry.emit(entry)

#generates timestamps
func current_time():
    var datetime: Dictionary = Time.get_time_dict_from_system()
    var datetime_string: String = "[%02d:%02d:%02d] " % [datetime["hour"],datetime["minute"],datetime["second"]] 
    return datetime_string