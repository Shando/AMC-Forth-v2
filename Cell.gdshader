shader_type canvas_item;

uniform vec4 color: source_color;

void vertex() {
	// Called for every vertex the material is visible on.
}

vec3 linear_to_srgb(vec3 linear) {
	return mix(1.055 * pow(linear, vec3(1.0 / 2.4)) - 0.055, linear * 12.92, lessThanEqual(linear, vec3(0.0031308)));
}

void fragment() {
	vec4 pixel_color = texture(TEXTURE, UV);
	//float a = pixel_color.a;
	//pixel_color.rgb = linear_to_srgb(color.rgb);
	//pixel_color.a = a;
	pixel_color.rgb *= color.rgb;
	pixel_color.a = color.a;
	COLOR = pixel_color;
}

//void light() {
	// Called for every pixel for every light affecting the CanvasItem.
	// Uncomment to replace the default light processing function with this one.
//}
