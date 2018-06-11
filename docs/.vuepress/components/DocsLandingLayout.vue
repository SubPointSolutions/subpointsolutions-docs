<template>
  <div class="home">

     <div class="hero">
      <h1>{{ data.heroText || $title || 'Hello' }}</h1>
      <p class="description">
        {{ data.tagline || $description || 'Welcome!' }}
      </p>
      <p class="action" v-if="data.actionText && data.actionLink">
        <NavLink class="action-button" :item="actionLink"/>
      </p>
    </div>
    <div class="features" v-if="data.features && data.features.length">
      <div class="feature" v-for="feature in data.features">
        <h2>
          <a :href=feature.url>
            {{ feature.title }}
          </a>
          </h2>
        <p>{{ feature.details }}</p>
      </div>
    </div>
    <div class="features-content">
      <Content custom/>
    </div>
    
    <div class="footer" v-html=" data.footer" v-if="data.footer">
      
    </div>
  </div>
</template>

<script>

export default {
  computed: {
    data () {
      return this.$page.frontmatter
    },
    actionLink () {
      return {
        link: this.data.actionLink,
        text: this.data.actionText
      }
    }
  }
}
</script>

<style>

.home {
  padding: 0rem 2rem 0;
}

.hoome .hero .description {
  font-size: 1.3rem !important;
}

.features-content {
  border-top: 1px solid #eaecef;
  padding: 1.2rem 0;
  margin-top: 2.5rem;
  display: flex;
  flex-wrap: wrap;
  align-items: flex-start;
  align-content: stretch;
  justify-content: space-between;
}

</style>