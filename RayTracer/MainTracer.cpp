// MainTracer.cpp
// Levi Purdy
// 11/10/2019
// Main application in which the ray tracer will be built

#pragma once


#include <iostream>
#include <fstream>
using namespace std;

#include "PPMTests.h"

int main() {
	std::ofstream ppmTestFile;
	ppmTestFile.open("ppmTest.PPM");
	testPPM(ppmTestFile);
	ppmTestFile.close();

	std::ofstream ppmTestFile2;
	ppmTestFile2.open("raysTest.PPM");
	testRays(ppmTestFile2);
	ppmTestFile.close();
}