import Nav from './Nav';
import CustomCarousel from './Carousel';
import React from 'react';
import Footer from './Footer';
import Welcome from './Welcome';
import CustomNav from './Nav';
function HomePage() {
  return (
    <div>
        <CustomCarousel />
        <Welcome/>
        <Footer/>
    </div>
  );
}

export default HomePage;
