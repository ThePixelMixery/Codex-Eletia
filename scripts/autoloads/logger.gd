extends Node

signal log_entry (entry: log)

'''
story, 
loot, 
unlock, 
tools 
'''

func add_event(message:String, type: String, reminder:bool = false):
    var allowed = false
    match type:
        "tools":
            pass
        "test":
            allowed = true
    if allowed:
        var entry = Label.new() 
        var message_total: String = message
        if reminder:
            message_total = "Reminder: " + message_total
        if sets.settings["events"]["settings"]:
            message_total = current_time() + message_total
        entry.text = message_total
        log_entry.emit(entry)

func current_time():
    var datetime: Dictionary = Time.get_time_dict_from_system()
    var datetime_string: String = "[%02d:%02d:%02d] " % [datetime["hour"],datetime["minute"],datetime["second"]] 
    return datetime_string
    
