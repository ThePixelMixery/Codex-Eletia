extends Node

# logging
signal log_entry (entry: log)

# world map
signal generate_map
signal map_generated(map_save)

# inventory/UI
signal tool_added (tool)
signal tool_removed (tool)
