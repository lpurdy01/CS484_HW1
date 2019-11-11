// PPMTest.cpp
// 11/10/2019
// Levi Purdy
// PPM tests

#include "PPMTests.h"

int testPPM(std::ostream & outputFile) {
	int nx = 200;
	int ny = 100;

	outputFile << "P3\n" << nx << " " << ny << "\n255\n";
	for (int j = 0; j < ny; j++) {
		for (int i = 0; i < nx; i++) {
			float r = float(i) / float(nx); 
			float g = float(j) / float(ny);
			float b = 0;

			int ir = int(255.99 * r);
			int ig = int(255.99 * g);
			int ib = int(255.99 * b);
			outputFile << ir << " " << ig << " " << ib << "\n";
		}
	}
	return 0;
}

vec3 missShader(const ray& r) {
	vec3 unit_direction = unit_vector(r.direction());
	float t = 0.5 * (unit_direction.y()) + 0.5;
	return (1.0 - t) * vec3(1.0, 1.0, 1.0) + t * vec3(0.5, 0.7, 1.0);
}

int testRaysMissShader(std::ostream& outputFile) {
	int nx = 200;
	int ny = 100;
	outputFile << "P3\n" << nx << " " << ny << "\n255\n";
	vec3 lower_left_corner(-2.0, -1.0, -1.0);
	vec3 horizontal(4.0, 0.0, 0.0);
	vec3 vertical(0.0, 2.0, 0.0);
	vec3 origin(0.0, 0.0, 0.0);
	for (int j = ny - 1; j >= 0; j--) {
		for (int i = 0; i < nx; i++) {
			float u = float(i) / float(nx);
			float v = float(j) / float(ny);

			ray r(origin, lower_left_corner + u * horizontal + v * vertical);
			vec3 col = missShader(r);

			int ir = int(255.99 * col[0]);
			int ig = int(255.99 * col[1]);
			int ib = int(255.99 * col[2]);

			outputFile << ir << " " << ig << " " << ib << "\n";
		}
	}
	return 0;
}


int testRays(std::ostream& outputFile) {
	int nx = 200;
	int ny = 100;
	outputFile << "P3\n" << nx << " " << ny << "\n255\n";
	vec3 lower_left_corner(-2.0, -1.0, -1.0);
	vec3 horizontal(4.0, 0.0, 0.0);
	vec3 vertical(0.0, 2.0, 0.0);
	vec3 origin(0.0, 0.0, 0.0);
	for (int j = ny - 1; j >= 0; j--) {
		for (int i = 0; i < nx; i++) {
			float u = float(i) / float(nx);
			float v = float(j) / float(ny);

			ray r(origin, lower_left_corner + u * horizontal + v * vertical);
			vec3 test = r.direction();

			vec3 col((test.x() + 2) / 4, (test.y() + 1) / 2, 0);


			int ir = int(255.99 * col[0]);
			int ig = int(255.99 * col[1]);
			int ib = 0;

			outputFile << ir << " " << ig << " " << ib << "\n";
		}
	}
	return 0;
}
