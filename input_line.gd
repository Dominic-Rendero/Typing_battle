extends LineEdit


# Called when the node enters the scene tree for the first time.
@onready var input_line = self
@onready var marker = get_node("/root/Node2D/Player1/hit_marker")
@onready var timer = get_node("/root/Node2D/Player1/hit_marker/flash_timer")


func _input(_event):
	if Input.is_action_pressed("ui_accept"):
		flash()
		
func flash():
	marker.visible = true
	timer.start()
func _on_timer_timeout():
	marker.visible = false
	pass # Replace with function body.
