import React, { useRef, createContext, useContext } from 'react';
import { fetchMovies } from '../services/fetchService';
import { SearchContext } from '../pages/UseContext';



function SearchForm() {

    const SetMovies = useContext(SearchContext);

    
    const searchInput = useRef();
    
    const handleSubmit = async (e) => {
        e.preventDefault();
        const res = await fetchMovies(searchInput.current.value);
        SetMovies(res);
    }


    return (
        <div className='m-5 h-12'>
            <form>
                <input className='w-96 h-[50px]' ref={searchInput} placeholder='Enter movie name' type='search' name="movie-name" id="movie-name" />
                <button onClick={(e) => handleSubmit(e)} type='submit'>Search</button>
            </form>
        </div>
    );
}
export default SearchForm;
