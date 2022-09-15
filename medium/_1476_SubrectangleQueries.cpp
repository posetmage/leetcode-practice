// 1476. Subrectangle Queries    

class SubrectangleQueries {
private:
    vector<vector<int>>& rectangle;
public:
    SubrectangleQueries(vector<vector<int>>& rectangle)
        :rectangle(rectangle)
    {
    }
    
    void updateSubrectangle(int row1, int col1, int row2, int col2, int newValue) {
		auto r_begin = rectangle.begin() + row1;
		auto r_end = rectangle.begin() + row2 + 1;
		for_each(r_begin, r_end, 
			[&newValue, &col1, &col2](vector<int>& col)
			{

				auto c_begin = col.begin() + col1;
				auto c_end = col.begin() + col2 + 1;
				for_each(c_begin, c_end, [&newValue](int& n) {
					n = newValue;
					});
			});
    }
    
    int getValue(int row, int col) {
        return rectangle[row][col];
    }

};