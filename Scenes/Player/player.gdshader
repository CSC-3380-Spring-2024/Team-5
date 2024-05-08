shader_type canvas_item;

uniform float time;

void fragment() {
    // Set a consistent ocean blue color tint
    vec3 blueTint = vec3(0.1, 0.4, 0.8);  // Ocean blue color tint

    // Set alpha to control transparency
    float alpha = 0.5;  // Adjust the alpha value to control the intensity of the tint

    // Apply the final color with adjusted alpha
    COLOR = vec4(blueTint, alpha);
}