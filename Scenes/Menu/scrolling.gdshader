shader_type canvas_item;

uniform float speed = .01;

void vertex() {
	UV.x += TIME * speed;
	
}

