import React, { Component } from 'react';
import PropTypes from 'prop-types';
import GoogleMapReact from 'google-map-react';

const GoogleMapMarker = ({ text, category }) =>
    <div style={{
        background: SimpleMap.setColour(category),
        width: '10px',
        height: '10px',
        display: 'inline-flex',
        textAlign: 'center',
        alignItems: 'center',
        justifyContent: 'center',
        borderRadius: '100%',
        transform: 'translate(-50%, -50%)'
    }}>
    </div>
    ;

export default class SimpleMap extends Component {

    static propTypes = {
        handleClick: PropTypes.func,
        crimes: PropTypes.array,
        center: PropTypes.object
    };

    constructor(props) {
        super(props);
        //console.log(this.state);
        //console.log(props);
        this.state = {
            center: { lat: Number(this.props.latitude), lng: Number(this.props.longitude) }
        };

    }

    static defaultProps = {
        zoom: 14
    }

    static setColour(category) {
        //console.log(category);
        switch (category) {
            case "violent-crime":
                return 'red';
            case "public-order":
                return 'blue';
            case "criminal-damage":
                return 'purple';
            case "burglary":
                return 'darkgoldenrod';
            default: return 'green';
        }
    }

    onMarkerClick = (evt) => {
        console.log('heelo');
    };

    renderMarkers(crimes) {
        return crimes.map(function(crime, index) {
            return (
                <GoogleMapMarker key={crime.id}
                    lat={crime.location.latitude}
                    lng={crime.location.longitude}
                    text={crime.category}
                    category={crime.category}
                />
            )
        })
    }

    render() {
        return (
            <GoogleMapReact
                bootstrapURLKeys={{ key: 'AIzaSyD0tJxM7TZLr8tYUTV_zKZSHXsrwzjI1bo' }}
                center={{ lat: Number(this.props.latitude), lng: Number(this.props.longitude) }}
                defaultCenter={this.state.center}
                defaultZoom={this.props.zoom}
            >
            {this.renderMarkers(this.props.crimes)}
            </GoogleMapReact>
        );
    }
}