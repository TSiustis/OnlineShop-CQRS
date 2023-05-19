import { Carousel } from 'react-bootstrap';
import React from 'react';

function CustomCarousel(){
    return(
        <Carousel>
        <Carousel.Item>
          <img
            className="d-block w-100"
            src="https://via.placeholder.com/1920x600?text=Carousel+1"
            alt="First slide"
          />
          <Carousel.Caption>
            <h3>Featured Product</h3>
            <p>Check out our latest and greatest item!</p>
          </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item>
          <img
            className="d-block w-100"
            src="https://via.placeholder.com/1920x600?text=Carousel+2"
            alt="Second slide"
          />
          <Carousel.Caption>
            <h3>New Arrivals</h3>
            <p>Shop our newest products today!</p>
          </Carousel.Caption>
        </Carousel.Item>
      </Carousel>
    );
}

export default CustomCarousel;