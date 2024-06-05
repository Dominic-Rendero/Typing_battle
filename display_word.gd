extends Label

var csv_file_path = "res://random_words_test.csv"
var words = []

@onready var word_display =  self
# Called when the node enters the scene tree for the first time.
func _ready():
	randomize()
	words = read_csv_into_list(csv_file_path)
	display_word()
	
func display_word():
	var random_index = randi() % words.size()
	var random_word = words[random_index]
	word_display.text = random_word
	
func _input(_event):
	if Input.is_action_pressed("ui_accept"):
		display_word()
		
func read_csv_into_list(path):
	var file = FileAccess.open(path, FileAccess.READ)
	var word_list = []

	if FileAccess.file_exists(path):
		while not file.eof_reached():
			var line = file.get_line()
			var word = line.strip_edges()
			if word != "":
				word_list.append(word)
		file.close()
	else:
		print("File not found: " + path)

	return word_list
