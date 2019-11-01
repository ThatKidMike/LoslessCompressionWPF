#include "Sign.h"

namespace ArithmeticCodingTmp {


	Sign::Sign(char sign, double probability)
		: sign(sign), probability(probability) {

	}

	Sign::~Sign(void) {

	}

	char Sign::GetSign() {
		return sign;
	}

	double Sign::GetProbability() {
		return probability;
	}

	double Sign::GetStartRange() {
		return this->startRange;
	}

	double Sign::GetEndRange() {
		return this->endRange;
	}

	void Sign::SetStartRange(double startRange) {
		this->startRange = startRange;
	}

	void Sign::SetEndRange(double endRange) {
		this->endRange = endRange;
	}



	double Sign::GetEncodedStart() {
		return this->encodedStart;
	}

	double Sign::GetEncodedEnd() {
		return this->encodedEnd;
	}

	void Sign::SetEncodedStart(double encodedStart) {
		this->encodedStart = encodedStart;
	}

	void Sign::SetEncodedEnd(double encodedEnd) {
		this->encodedEnd = encodedEnd;
	}

	void Sign::SetProbability(int probability) {
		this->probability = probability;
	}


}